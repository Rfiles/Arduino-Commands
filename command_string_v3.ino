//#################################################################################################
//  MADE BY ElectronicaSul  -  2016-OCT-01
//#################################################################################################
//
//      User Configurations 
//      -> use // to disable function
//#################################################################################################

#define ENABLE_UV
#define ENABLE_COLOR
#define ENABLE_RTC
#define ENABLE_BME280
#define ENABLE_MPU6050
#define ENABLE_LIGHT
//#define ENABLE_GPS

// USER CONFIGURATION ABOVE ONLY
//#################################################################################################
//  INCLUDES
//#################################################################################################

#include <Wire.h>
#ifdef ENABLE_COLOR
  #include "Adafruit_TCS34725.h"
#endif
#ifdef ENABLE_BME280
  #include <Adafruit_Sensor.h>
  #include <Adafruit_BME280.h>
#endif
#ifdef ENABLE_RTC
  #include "RTClib.h"
#endif
#ifdef ENABLE_MPU6050
  #include "MPU6050.h"
#endif
#ifdef ENABLE_UV
  #include "Adafruit_VEML6070.h"
#endif
#ifdef ENABLE_LIGHT
  #include <BH1750.h>
#endif
#ifdef ENABLE_GPS
  #include <SoftwareSerial.h>
  #include <TinyGPS.h>
#endif

//#################################################################################################
// DEFINITIONS
//#################################################################################################

String    id_string;
String    value_string;
uint8_t   parse_stat; // 0 no data - 1 command started - 2 command ended, not executed
uint8_t   content;    // 0 no content - 1 write - 2 read
uint8_t   isData;
char      byterx;

#ifdef ENABLE_COLOR

#define TCS34725_R_Coef 0.136
#define TCS34725_G_Coef 1.000
#define TCS34725_B_Coef -0.444
#define TCS34725_GA 1.0
#define TCS34725_DF 310.0
#define TCS34725_CT_Coef 3810.0
#define TCS34725_CT_Offset 1391.0

// Autorange class for TCS34725
class tcs34725 {
  public:
    tcs34725(void);

    boolean begin(void);
    void getData(void);

    boolean isAvailable, isSaturated;
    uint16_t againx, atime, atime_ms;
    uint16_t r, g, b, c;
    uint16_t ir;
    uint16_t r_comp, g_comp, b_comp, c_comp;
    uint16_t saturation, saturation75;
    float cratio, cpl, ct, lux, maxlux;

  private:
    struct tcs_agc {
      tcs34725Gain_t ag;
      tcs34725IntegrationTime_t at;
      uint16_t mincnt;
      uint16_t maxcnt;
    };
    static const tcs_agc agc_lst[];
    uint16_t agc_cur;

    void setGainTime(void);
    Adafruit_TCS34725 tcs;
};

const tcs34725::tcs_agc tcs34725::agc_lst[] = {
  { TCS34725_GAIN_60X, TCS34725_INTEGRATIONTIME_700MS,     0, 47566 },
  { TCS34725_GAIN_16X, TCS34725_INTEGRATIONTIME_154MS,  3171, 63422 },
  { TCS34725_GAIN_4X,  TCS34725_INTEGRATIONTIME_154MS, 15855, 63422 },
  { TCS34725_GAIN_1X,  TCS34725_INTEGRATIONTIME_2_4MS,   248,     0 }
};

tcs34725::tcs34725() : agc_cur(0), isAvailable(0), isSaturated(0) {
}

// initialize the sensor
boolean tcs34725::begin(void) {
  tcs = Adafruit_TCS34725(agc_lst[agc_cur].at, agc_lst[agc_cur].ag);
  if ((isAvailable = tcs.begin()))
    setGainTime();
  return (isAvailable);
}

// Set the gain and integration time
void tcs34725::setGainTime(void) {
  tcs.setGain(agc_lst[agc_cur].ag);
  tcs.setIntegrationTime(agc_lst[agc_cur].at);
  atime = int(agc_lst[agc_cur].at);
  atime_ms = ((256 - atime) * 2.4);
  switch (agc_lst[agc_cur].ag) {
    case TCS34725_GAIN_1X:
      againx = 1;
      break;
    case TCS34725_GAIN_4X:
      againx = 4;
      break;
    case TCS34725_GAIN_16X:
      againx = 16;
      break;
    case TCS34725_GAIN_60X:
      againx = 60;
      break;
  }
}

// Retrieve data from the sensor and do the calculations
void tcs34725::getData(void) {
  // read the sensor and autorange if necessary
  tcs.getRawData(&r, &g, &b, &c);
  while (1) {
    if (agc_lst[agc_cur].maxcnt && c > agc_lst[agc_cur].maxcnt)
      agc_cur++;
    else if (agc_lst[agc_cur].mincnt && c < agc_lst[agc_cur].mincnt)
      agc_cur--;
    else break;

    setGainTime();
    delay((256 - atime) * 2.4 * 2); // shock absorber
    tcs.getRawData(&r, &g, &b, &c);
    break;
  }

  // DN40 calculations
  ir = (r + g + b > c) ? (r + g + b - c) / 2 : 0;
  r_comp = r - ir;
  g_comp = g - ir;
  b_comp = b - ir;
  c_comp = c - ir;
  cratio = float(ir) / float(c);

  saturation = ((256 - atime) > 63) ? 65535 : 1024 * (256 - atime);
  saturation75 = (atime_ms < 150) ? (saturation - saturation / 4) : saturation;
  isSaturated = (atime_ms < 150 && c > saturation75) ? 1 : 0;
  cpl = (atime_ms * againx) / (TCS34725_GA * TCS34725_DF);
  maxlux = 65535 / (cpl * 3);

  lux = (TCS34725_R_Coef * float(r_comp) + TCS34725_G_Coef * float(g_comp) + TCS34725_B_Coef * float(b_comp)) / cpl;
  ct = TCS34725_CT_Coef * float(b_comp) / float(r_comp) + TCS34725_CT_Offset;
}

tcs34725 rgb_sensor;
#endif

#ifdef ENABLE_BME280
  #define SEALEVELPRESSURE_HPA (1013.25)
  Adafruit_BME280 bme; // I2C
#endif
#ifdef ENABLE_RTC
  char daysOfTheWeek[7][12] = {"Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab"};  // this is in pt-PT
  RTC_DS3231 rtc;
#endif
#ifdef ENABLE_MPU6050
  int16_t ax, ay, az;
  int16_t gx, gy, gz;
  MPU6050 accelgyro;
#endif
#ifdef ENABLE_UV
  Adafruit_VEML6070 uv = Adafruit_VEML6070();
#endif
#ifdef ENABLE_LIGHT
  BH1750 lightMeter;
#endif
#ifdef ENABLE_GPS
  TinyGPS gps;
  SoftwareSerial ss(4, 3);
  bool newData = false;
  unsigned long chars;
  unsigned short sentences, failed;
#endif

int var1;

//#################################################################################################
// SETUP
//#################################################################################################
void setup() {
  Serial.begin(115200);
  while (!Serial); // Para o arduino leonardo
  #ifdef ENABLE_COLOR
    if (!rgb_sensor.begin()) Serial.print(F("<COLOR_BOOT=FAIL>"));
    pinMode(PD6, OUTPUT);
  #endif
  #ifdef ENABLE_BME280
    if (!bme.begin()) Serial.print(F("<BME280_BOOT=FAIL>"));
  #endif
  #ifdef ENABLE_RTC
    if (!rtc.begin()) {
      Serial.print(F("<RTC_BOOT=FAIL>"));
    } else {
      if (rtc.lostPower()) {
        rtc.adjust(DateTime(F(__DATE__), F(__TIME__)));
        Serial.print(F("<RTC_STAT=LOST_TIME>"));
      }
    }
  #endif
  #ifdef ENABLE_MPU6050
    accelgyro.initialize();   //doesnt have return value
    Serial.print(F("<MPU6050_BOOT=UNKNOWN>"));
  #endif    
  #ifdef ENABLE_UV
    uv.begin(VEML6070_1_T);   //doesnt have return value
    Serial.print(F("<UV_BOOT=UNKNOWN>"));
  #endif
  #ifdef ENABLE_LIGHT
    lightMeter.begin();       //doesnt have return value
    Serial.print(F("<LIGHT_BOOT=UNKNOWN>"));
  #endif
  #ifdef ENABLE_GPS
    ss.begin(4800);
  #endif
  Serial.println(F("<BOOT=DONE>"));
  pinMode(LED_BUILTIN, OUTPUT);
}

//#################################################################################################
// LOOP
//#################################################################################################
void loop() {

  if (Serial.available()) {
    byterx = Serial.read();

    switch (byterx) {
      case '<':
        parse_stat = 1;   //command start
        isData = 0;
        break;
      case '=':
        content = 1;  // write
        isData = 0;
        break;
      case '?':
        content = 2;  // read
        isData = 0;
        break;
      case '>':
        if ( parse_stat == 1 ) {
          parse_stat = 2;   // command end; execute
        } else {
          ResetStrings();   // command didnt start; abort
        }
        isData = 0;
        break;
      case 10:    //ignore
        break;
      case 13:    //ignore
        break;
      case 0:
        ResetStrings();
        break;
      default:
        isData = 1;   //its data
        break;
    }//switch

    if ((parse_stat == 1) && (content == 0) && (isData == 1)) id_string += byterx;   // its ID
    if ((parse_stat == 1) && (content > 0) && (isData == 1)) value_string += byterx; // its Value
    if ((parse_stat == 2) && (content == 0)) ResetStrings();                         // bad command (sem read ou write)
    if ((parse_stat == 2) && (content > 0) && (isData == 0)) ExecuteCommand();       // command done

  }//if
  #ifdef ENABLE_GPS
    process_gps();
  #endif
    
}//func

//#################################################################################################
// REMOTE COMMANDS FUNCTION
//#################################################################################################
void ExecuteCommand() {
  if (content == 1) {           //write
    if (id_string == "VAR1" ) {
      var1 = value_string.toInt();
      Serial.print(F("<VAR1="));
      Serial.print(var1);
      Serial.println(F(">"));
    }
    if (id_string == "LED13" ) {
      if ( value_string == "ON" ) {
        digitalWrite(LED_BUILTIN, HIGH);
        Serial.print(F("<LED13=ON>"));
      }
      if ( value_string == "OFF" ) {
        digitalWrite(LED_BUILTIN, LOW);
        Serial.print(F("<LED13=OFF>"));
      }
    }
    #ifdef ENABLE_COLOR
    if (id_string == "COLOR_LED" ) {
      if ( value_string == "ON" ) {
        digitalWrite(PD6, HIGH);
        Serial.print(F("<COLOR_LED=ON>"));
      }
      if ( value_string == "OFF" ) {
        digitalWrite(PD6, LOW);
        Serial.print(F("<COLOR_LED=OFF>"));
      }
    }
    #endif
  }//end if c=1 WRITE

  if (content == 2) {           //read
    if (id_string == "VAR1" ) {
      Serial.print(F("<VAR1="));
      Serial.print(var1);
      Serial.println(F(">"));
    }
    #ifdef ENABLE_COLOR
      if (id_string == "COLOR" ) ColorSensorRead();
    #endif
    #ifdef ENABLE_BME280
      if (id_string == "BME" ) BME_Data();
    #endif
    #ifdef ENABLE_RTC
      if (id_string == "RTC" ) RTC_Data();
    #endif
    #ifdef ENABLE_MPU6050
      if (id_string == "MPU" ) MPU_Data();
    #endif
    #ifdef ENABLE_UV
      if (id_string == "UV" ) UV_Data();
    #endif
    #ifdef ENABLE_LIGHT
      if (id_string == "LIGHT" ) LIGHT_Data();
    #endif
    #ifdef ENABLE_GPS
      if (id_string == "GPS" ) GPS_Data();
    #endif
    if (id_string == "ALL" ) {
      LED13_Data();
      #ifdef ENABLE_COLOR
        ColorSensorRead();
      #endif
      #ifdef ENABLE_LIGHT
        LIGHT_Data();
      #endif
      #ifdef ENABLE_BME280
        BME_Data();
      #endif
      #ifdef ENABLE_RTC
        RTC_Data();
      #endif
      #ifdef ENABLE_MPU6050
        MPU_Data();
      #endif
      #ifdef ENABLE_UV
        UV_Data();
      #endif
      #ifdef ENABLE_GPS
        GPS_Data();
      #endif
    }

    if (id_string == "LED13" ) LED13_Data();
  }//end if c=2 READ

  ResetStrings();
}//func

void ResetStrings() {
  parse_stat = 0;
  content = 0;
  value_string = "";
  id_string = "";
  isData = 0;
}

//#################################################################################################
// LIBRARIES FUNCTIONS
//#################################################################################################

void LED13_Data() {
    if (digitalRead(LED_BUILTIN)) {
      Serial.println(F("<LED13=ON>"));
    } else {
      Serial.println(F("<LED13=OFF>"));
    }
}

#ifdef ENABLE_COLOR
void ColorSensorRead() {
  rgb_sensor.getData();
  Serial.print(F("<COLOR_GA="));
  Serial.print(rgb_sensor.againx);
  Serial.print(F("><COLOR_TI="));
  Serial.print(rgb_sensor.atime_ms);
  Serial.print(F("><COLOR_TH="));
  Serial.print(rgb_sensor.atime, HEX);
  Serial.print(F("><COLOR_R_RAW="));
  Serial.print(rgb_sensor.r);
  Serial.print(F("><COLOR_G_RAW="));
  Serial.print(rgb_sensor.g);
  Serial.print(F("><COLOR_B_RAW="));
  Serial.print(rgb_sensor.b);
  Serial.print(F("><COLOR_C_RAW="));
  Serial.print(rgb_sensor.c);
  Serial.print(F("><COLOR_IR_RAW="));
  Serial.print(rgb_sensor.ir);
  Serial.print(F("><COLOR_CRATIO="));
  Serial.print(rgb_sensor.cratio);
  Serial.print(F("><COLOR_SAT="));
  Serial.print(rgb_sensor.saturation);
  Serial.print(F("><COLOR_SAT75="));
  Serial.print(rgb_sensor.saturation75);
  Serial.print(F("><COLOR_ISSAT="));
  Serial.print(rgb_sensor.isSaturated ? "YES" : "NO");
  Serial.print(F("><COLOR_CPL="));
  Serial.print(rgb_sensor.cpl);
  Serial.print(F("><COLOR_MAXLUX="));
  Serial.print(rgb_sensor.maxlux);
  Serial.print(F("><COLOR_R_COMP="));
  Serial.print(rgb_sensor.r_comp);
  Serial.print(F("><COLOR_G_COMP="));
  Serial.print(rgb_sensor.g_comp);
  Serial.print(F("><COLOR_B_COMP="));
  Serial.print(rgb_sensor.b_comp);
  Serial.print(F("><COLOR_C_COMP="));
  Serial.print(rgb_sensor.c_comp);
  Serial.print(F("><COLOR_LUX="));
  Serial.print(rgb_sensor.lux);
  Serial.print(F("><COLOR_CT="));
  Serial.print(rgb_sensor.ct);
  Serial.println(F(">"));

}
#endif

#ifdef ENABLE_BME280
void BME_Data() {
  Serial.print(F("<BME_T="));
  Serial.print(bme.readTemperature());
  Serial.print(F("><BME_P="));
  Serial.print(bme.readPressure() / 100.0F);
  Serial.print(F("><BME_A="));
  Serial.print(bme.readAltitude(SEALEVELPRESSURE_HPA));
  Serial.print(F("><BME_H="));
  Serial.print(bme.readHumidity());
  Serial.println(F(">"));

}
#endif

#ifdef ENABLE_RTC
void RTC_Data() {
  DateTime now = rtc.now();
  Serial.print(F("<RTC_Y="));
  Serial.print(now.year(), DEC);
  Serial.print(F("><RTC_M="));
  Serial.print(now.month(), DEC);
  Serial.print(F("><RTC_D="));
  Serial.print(now.day(), DEC);
  Serial.print(F("><RTC_W="));
  Serial.print(daysOfTheWeek[now.dayOfTheWeek()]);
  Serial.print(F("><RTC_H="));
  Serial.print(now.hour(), DEC);
  Serial.print(F("><RTC_N="));
  Serial.print(now.minute(), DEC);
  Serial.print(F("><RTC_S="));
  Serial.print(now.second(), DEC);
  Serial.println(F(">"));
}
#endif

#ifdef ENABLE_MPU6050
void MPU_Data() {
  accelgyro.getMotion6(&ax, &ay, &az, &gx, &gy, &gz);
  Serial.print(F("<ACC_X="));
  Serial.print(ax); 
  Serial.print(F("><ACC_Y="));
  Serial.print(ay); 
  Serial.print(F("><ACC_Z="));
  Serial.print(az); 
  Serial.print(F("><GRA_X="));
  Serial.print(gx); 
  Serial.print(F("><GRA_Y="));
  Serial.print(gy); 
  Serial.print(F("><GRA_Z="));
  Serial.print(gz);
  Serial.println(F(">"));
}
#endif

#ifdef ENABLE_UV
void UV_Data() {
  Serial.print(F("<UV_L="));
  Serial.print(uv.readUV());
  Serial.println(F(">"));
}
#endif

#ifdef ENABLE_LIGHT
void LIGHT_Data() {
  uint16_t lux = lightMeter.readLightLevel();
  Serial.print("<LIGHT_LUX=");
  Serial.print(lux);
  Serial.println(">");
}
#endif

#ifdef ENABLE_GPS
void process_gps() {
  // For one second we parse GPS data and report some key values
  for (unsigned long start = millis(); millis() - start < 1000;){
    while (ss.available())    {
      char c = ss.read();
      // Serial.write(c); // uncomment this line if you want to see the GPS data flowing
      if (gps.encode(c)) // Did a new valid sentence come in?
        newData = true;
    }
  }
}
void GPS_Data() {
  if (newData) {
    float flat, flon;
    unsigned long age;
    gps.f_get_position(&flat, &flon, &age);
    Serial.print("<GPS_LAT=");
    Serial.print(flat == TinyGPS::GPS_INVALID_F_ANGLE ? 0.0 : flat, 6);
    Serial.print("><GPS_LON=");
    Serial.print(flon == TinyGPS::GPS_INVALID_F_ANGLE ? 0.0 : flon, 6);
    Serial.print("><GPS_SAT=");
    Serial.print(gps.satellites() == TinyGPS::GPS_INVALID_SATELLITES ? 0 : gps.satellites());
    Serial.print("><GPS_PREC=");
    Serial.print(gps.hdop() == TinyGPS::GPS_INVALID_HDOP ? 0 : gps.hdop());
    Serial.println(">");
  }
  
  gps.stats(&chars, &sentences, &failed);
  Serial.print("<GPS_CHARS=");
  Serial.print(chars);
  Serial.print("><GPS_LINES=");
  Serial.print(sentences);
  Serial.print("><GPS_CSUM_ERR=");
  Serial.print(failed);
  Serial.println(">");
}
#endif

//#################################################################################################
// END OF FILE
//#################################################################################################




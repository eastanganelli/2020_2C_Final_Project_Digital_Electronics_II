#include <stdlibm.h>
#include <string.h>
#define SEP '\n'
#define END '\0'

struct SERIAL_LIB {
    char* sSerial;
}; typedef struct SERIAL_LIB SERIALsr;

SERIALsr serialData;
char str[9] = "\0";

// SEND SYSTEM
void set_SERIALsr() {
    serialData.sSerial = malloc(sizeof(char));
}
void sendFT(char t , float v, char a) {
    sprintf(str, "%c%f%c", t, v, a);
    for(int i = 0; str[i] != a; i++)
        printf("%c", str[i]);
    printf("%c", a);
}
void sendINT(char t , int v, char a) {
    sprintf(str, "%c%d%c", t, v, a);
    for(int i = 0; str[i] != a; i++)
        printf("%c", str[i]);
    printf("%c", a);
}
void sendSTR(char t , char v[], char a) {
    sprintf(str, "%c%s%c", t, v, a);
        for(int i = 0; str[i] != a; i++)
            printf("%c", str[i]);
    printf("%c", a);
}
void sendDATA(char s_[], char a) {
     for(int i = 0; s_[i] != a; i++)
         printf("%c", s_[i]);
    printf("%c", a);
}
// END SEND SYSTEM
// READ SERIAL
int getArrSize() { return strlen(serialData.sSerial); }
int insert(char c_) {
    int i = 0;
    serialData.sSerial = realloc(serialData.sSerial, sizeof(char)*(i + 1));
    if(serialData.sSerial != NULL) {
        i++;
        *(serialData.sSerial + getArrSize() - 1) = c_;
        return TRUE;
    } return FALSE;
}
char* getSTR() { return serialData.sSerial; }
// END READ SERIAL

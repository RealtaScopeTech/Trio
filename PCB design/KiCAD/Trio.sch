EESchema Schematic File Version 4
EELAYER 30 0
EELAYER END
$Descr A4 11693 8268
encoding utf-8
Sheet 1 1
Title ""
Date ""
Rev ""
Comp ""
Comment1 ""
Comment2 ""
Comment3 ""
Comment4 ""
$EndDescr
$Comp
L Connector:Barrel_Jack_Switch PO1
U 1 1 5FDB8D96
P 10700 1050
F 0 "PO1" H 10757 1375 50  0000 C CNN
F 1 "BJ" H 10757 1284 50  0000 C CNN
F 2 "Connector_BarrelJack:BarrelJack_Wuerth_6941xx301002" H 10750 1010 50  0001 C CNN
F 3 "~" H 10750 1010 50  0001 C CNN
	1    10700 1050
	-1   0    0    -1  
$EndComp
$Comp
L Device:Fuse F3
U 1 1 5FDC3466
P 10250 950
F 0 "F3" V 10053 950 50  0000 C CNN
F 1 "3A" V 10144 950 50  0000 C CNN
F 2 "Fuse:Fuse_1206_3216Metric" V 10180 950 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Shenzhen-lanson-Elec-12H1300C_C182445.pdf" H 10250 950 50  0001 C CNN
F 4 " C182445" H 10250 950 50  0001 C CNN "LCSC Part #"
	1    10250 950 
	0    1    1    0   
$EndComp
$Comp
L Device:Fuse F1
U 1 1 5FDC57E5
P 1850 850
F 0 "F1" V 1653 850 50  0000 C CNN
F 1 "3A" V 1744 850 50  0000 C CNN
F 2 "Fuse:Fuse_1206_3216Metric" V 1780 850 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Shenzhen-lanson-Elec-12H1300C_C182445.pdf" H 1850 850 50  0001 C CNN
F 4 " C182445" H 1850 850 50  0001 C CNN "LCSC Part #"
	1    1850 850 
	0    1    1    0   
$EndComp
$Comp
L Device:R R4
U 1 1 5FE0223B
P 3850 4700
F 0 "R4" H 3920 4746 50  0000 L CNN
F 1 "330" H 3920 4655 50  0000 L CNN
F 2 "Resistor_SMD:R_0805_2012Metric" V 3780 4700 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Uniroyal-Elec-0805W8F3300T5E_C17630.pdf" H 3850 4700 50  0001 C CNN
F 4 "C17630" H 3850 4700 50  0001 C CNN "LCSC Part #"
	1    3850 4700
	0    -1   -1   0   
$EndComp
$Comp
L Device:R R6
U 1 1 5FE04F03
P 3850 5650
F 0 "R6" H 3920 5696 50  0000 L CNN
F 1 "330" H 3920 5605 50  0000 L CNN
F 2 "Resistor_SMD:R_0805_2012Metric" V 3780 5650 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Uniroyal-Elec-0805W8F3300T5E_C17630.pdf" H 3850 5650 50  0001 C CNN
F 4 "C17630" H 3850 5650 50  0001 C CNN "LCSC Part #"
	1    3850 5650
	0    -1   -1   0   
$EndComp
$Comp
L Device:R R5
U 1 1 5FE0438D
P 3850 5150
F 0 "R5" H 3920 5196 50  0000 L CNN
F 1 "330" H 3920 5105 50  0000 L CNN
F 2 "Resistor_SMD:R_0805_2012Metric" V 3780 5150 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Uniroyal-Elec-0805W8F3300T5E_C17630.pdf" H 3850 5150 50  0001 C CNN
F 4 "C17630" H 3850 5150 50  0001 C CNN "LCSC Part #"
	1    3850 5150
	0    -1   -1   0   
$EndComp
Wire Wire Line
	4650 4900 4550 4900
$Comp
L Device:Fuse F8
U 1 1 5FE36FA5
P 8300 2000
F 0 "F8" V 8103 2000 50  0000 C CNN
F 1 "3A" V 8194 2000 50  0000 C CNN
F 2 "Fuse:Fuse_1206_3216Metric" V 8230 2000 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Shenzhen-lanson-Elec-12H1300C_C182445.pdf" H 8300 2000 50  0001 C CNN
F 4 " C182445" H 8300 2000 50  0001 C CNN "LCSC Part #"
	1    8300 2000
	-1   0    0    1   
$EndComp
$Comp
L RCJ-047:RCJ-047 DO1
U 1 1 5FDB9229
P 1000 950
F 0 "DO1" H 900 1250 50  0000 C CNN
F 1 "RCJ-047" H 900 1150 50  0000 C CNN
F 2 "Trio:CUI_RCJ-047" H 1050 910 50  0001 C CNN
F 3 "~" H 1050 910 50  0001 C CNN
	1    1000 950 
	1    0    0    -1  
$EndComp
Wire Wire Line
	4650 4800 4450 4800
$Comp
L Device:CP C1
U 1 1 5FDBE7C4
P 8700 3600
F 0 "C1" H 8818 3646 50  0000 L CNN
F 1 "C311622" H 8818 3555 50  0000 L CNN
F 2 "Capacitor_SMD:CP_Elec_6.3x7.7" H 8738 3450 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Lite-On-Semicon-VE-101M1CTR-0605_C134723.pdf" H 8700 3600 50  0001 C CNN
F 4 "C311622" H 8700 3600 50  0001 C CNN "LCSC Part #"
	1    8700 3600
	1    0    0    -1  
$EndComp
$Comp
L Mechanical:MountingHole H1
U 1 1 5FEE6B78
P 10100 5250
F 0 "H1" H 10200 5296 50  0000 L CNN
F 1 "MountingHole" H 10200 5205 50  0000 L CNN
F 2 "MountingHole:MountingHole_2.2mm_M2" H 10100 5250 50  0001 C CNN
F 3 "~" H 10100 5250 50  0001 C CNN
	1    10100 5250
	1    0    0    -1  
$EndComp
$Comp
L Mechanical:MountingHole H2
U 1 1 5FF0686D
P 10100 5550
F 0 "H2" H 10200 5596 50  0000 L CNN
F 1 "MountingHole" H 10200 5505 50  0000 L CNN
F 2 "MountingHole:MountingHole_2.2mm_M2" H 10100 5550 50  0001 C CNN
F 3 "~" H 10100 5550 50  0001 C CNN
	1    10100 5550
	1    0    0    -1  
$EndComp
$Comp
L Mechanical:MountingHole H3
U 1 1 5FF0CC9B
P 10100 5850
F 0 "H3" H 10200 5896 50  0000 L CNN
F 1 "MountingHole" H 10200 5805 50  0000 L CNN
F 2 "MountingHole:MountingHole_2.2mm_M2" H 10100 5850 50  0001 C CNN
F 3 "~" H 10100 5850 50  0001 C CNN
	1    10100 5850
	1    0    0    -1  
$EndComp
$Comp
L Mechanical:MountingHole H4
U 1 1 5FF12FCC
P 10100 6250
F 0 "H4" H 10200 6296 50  0000 L CNN
F 1 "MountingHole" H 10200 6205 50  0000 L CNN
F 2 "MountingHole:MountingHole_2.2mm_M2" H 10100 6250 50  0001 C CNN
F 3 "~" H 10100 6250 50  0001 C CNN
	1    10100 6250
	1    0    0    -1  
$EndComp
Wire Wire Line
	10400 1050 10400 1150
Wire Wire Line
	10400 1250 10400 1150
Connection ~ 10400 1150
$Comp
L Connector:Barrel_Jack_Switch PO2
U 1 1 60129FEB
P 10700 2000
F 0 "PO2" H 10757 2325 50  0000 C CNN
F 1 "BJ" H 10757 2234 50  0000 C CNN
F 2 "Connector_BarrelJack:BarrelJack_Wuerth_6941xx301002" H 10750 1960 50  0001 C CNN
F 3 "~" H 10750 1960 50  0001 C CNN
	1    10700 2000
	-1   0    0    -1  
$EndComp
$Comp
L Device:Fuse F4
U 1 1 60129FF1
P 10250 1900
F 0 "F4" V 10053 1900 50  0000 C CNN
F 1 "3A" V 10144 1900 50  0000 C CNN
F 2 "Fuse:Fuse_1206_3216Metric" V 10180 1900 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Shenzhen-lanson-Elec-12H1300C_C182445.pdf" H 10250 1900 50  0001 C CNN
F 4 " C182445" H 10250 1900 50  0001 C CNN "LCSC Part #"
	1    10250 1900
	0    1    1    0   
$EndComp
Wire Wire Line
	10400 2000 10400 2100
Wire Wire Line
	10400 2200 10400 2100
Connection ~ 10400 2100
$Comp
L Connector:Barrel_Jack_Switch PO3
U 1 1 60132E53
P 10700 2950
F 0 "PO3" H 10757 3275 50  0000 C CNN
F 1 "BJ" H 10757 3184 50  0000 C CNN
F 2 "Connector_BarrelJack:BarrelJack_Wuerth_6941xx301002" H 10750 2910 50  0001 C CNN
F 3 "~" H 10750 2910 50  0001 C CNN
	1    10700 2950
	-1   0    0    -1  
$EndComp
$Comp
L Device:Fuse F6
U 1 1 60132E59
P 10250 2850
F 0 "F6" V 10053 2850 50  0000 C CNN
F 1 "3A" V 10144 2850 50  0000 C CNN
F 2 "Fuse:Fuse_1206_3216Metric" V 10180 2850 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Shenzhen-lanson-Elec-12H1300C_C182445.pdf" H 10250 2850 50  0001 C CNN
F 4 " C182445" H 10250 2850 50  0001 C CNN "LCSC Part #"
	1    10250 2850
	0    1    1    0   
$EndComp
Wire Wire Line
	10400 2950 10400 3050
Wire Wire Line
	10400 3150 10400 3050
Connection ~ 10400 3050
Wire Wire Line
	1200 1150 1200 1050
Wire Wire Line
	1750 3900 1650 3900
$Comp
L RCJ-047:RCJ-047 DO2
U 1 1 602F0053
P 1050 3700
F 0 "DO2" H 900 4000 50  0000 C CNN
F 1 "RCJ-047" H 950 3900 50  0000 C CNN
F 2 "Trio:CUI_RCJ-047" H 1100 3660 50  0001 C CNN
F 3 "~" H 1100 3660 50  0001 C CNN
	1    1050 3700
	1    0    0    -1  
$EndComp
Wire Wire Line
	1250 3900 1250 3800
$Comp
L RCJ-047:RCJ-047 DO3
U 1 1 602FA583
P 1000 2400
F 0 "DO3" H 900 2700 50  0000 C CNN
F 1 "RCJ-047" H 900 2600 50  0000 C CNN
F 2 "Trio:CUI_RCJ-047" H 1050 2360 50  0001 C CNN
F 3 "~" H 1050 2360 50  0001 C CNN
	1    1000 2400
	1    0    0    -1  
$EndComp
Wire Wire Line
	1200 2600 1200 2500
Text GLabel 1200 4200 0    50   Input ~ 0
LOGIC3
Text GLabel 3700 4700 0    50   Input ~ 0
LOGIC1
Text GLabel 3700 5150 0    50   Input ~ 0
LOGIC2
Text GLabel 3700 5650 0    50   Input ~ 0
LOGIC3
Wire Wire Line
	4000 4700 4650 4700
Wire Wire Line
	4450 4800 4450 5150
Wire Wire Line
	4000 5150 4450 5150
Wire Wire Line
	4550 5650 4000 5650
Wire Wire Line
	4550 5650 4550 4900
$Comp
L Connector:RJ12 J1
U 1 1 60167634
P 10500 4250
F 0 "J1" H 10170 4254 50  0000 R CNN
F 1 "RJ12" H 10170 4345 50  0000 R CNN
F 2 "Connector_RJ:RJ12_Amphenol_54601" V 10500 4275 50  0001 C CNN
F 3 "~" V 10500 4275 50  0001 C CNN
	1    10500 4250
	-1   0    0    1   
$EndComp
$Comp
L Transistor_FET:2N7002K NM3
U 1 1 602F004D
P 1450 4000
F 0 "NM3" V 1792 4000 50  0000 C CNN
F 1 "AO3400A" V 1701 4000 50  0000 C CNN
F 2 "Package_TO_SOT_SMD:SOT-23" H 1650 3925 50  0001 L CIN
F 3 "https://datasheet.lcsc.com/szlcsc/Alpha-Omega-Semicon-AOS-AO3400A_C20917.pdf" H 1450 4000 50  0001 L CNN
F 4 "C20917" H 1450 4000 50  0001 C CNN "LCSC Part #"
	1    1450 4000
	0    -1   -1   0   
$EndComp
$Comp
L Device:R R2
U 1 1 602F0059
P 1750 4200
F 0 "R2" H 1820 4246 50  0000 L CNN
F 1 "10K" H 1820 4155 50  0000 L CNN
F 2 "Resistor_SMD:R_0805_2012Metric" V 1680 4200 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Uniroyal-Elec-0805W8F1002T5E_C17414.pdf" H 1750 4200 50  0001 C CNN
F 4 "C17414" H 1750 4200 50  0001 C CNN "LCSC Part #"
	1    1750 4200
	0    1    1    0   
$EndComp
$Comp
L power:GND #PWR0101
U 1 1 5FEB47B4
P 1750 3900
F 0 "#PWR0101" H 1750 3650 50  0001 C CNN
F 1 "GND" H 1755 3727 50  0000 C CNN
F 2 "" H 1750 3900 50  0001 C CNN
F 3 "" H 1750 3900 50  0001 C CNN
	1    1750 3900
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR0102
U 1 1 5FEB82BE
P 2150 4250
F 0 "#PWR0102" H 2150 4000 50  0001 C CNN
F 1 "GND" H 2155 4077 50  0000 C CNN
F 2 "" H 2150 4250 50  0001 C CNN
F 3 "" H 2150 4250 50  0001 C CNN
	1    2150 4250
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR0103
U 1 1 5FEEB2DE
P 8200 5050
F 0 "#PWR0103" H 8200 4800 50  0001 C CNN
F 1 "GND" H 8205 4877 50  0000 C CNN
F 2 "" H 8200 5050 50  0001 C CNN
F 3 "" H 8200 5050 50  0001 C CNN
	1    8200 5050
	1    0    0    -1  
$EndComp
$Comp
L WillsLib:FC681495 PI1
U 1 1 5FDB6FE7
P 6250 1400
F 0 "PI1" H 6900 1700 50  0000 C CNN
F 1 "BJ" H 6850 1600 50  0000 C CNN
F 2 "Trio:FC681495" H 6300 1360 50  0001 C CNN
F 3 "~" H 6300 1360 50  0001 C CNN
	1    6250 1400
	-1   0    0    -1  
$EndComp
$Comp
L power:+12V #PWR0107
U 1 1 609B5AAF
P 2850 850
F 0 "#PWR0107" H 2850 700 50  0001 C CNN
F 1 "+12V" H 2865 1023 50  0000 C CNN
F 2 "" H 2850 850 50  0001 C CNN
F 3 "" H 2850 850 50  0001 C CNN
	1    2850 850 
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR0108
U 1 1 5FEAF314
P 2100 1500
F 0 "#PWR0108" H 2100 1250 50  0001 C CNN
F 1 "GND" H 2105 1327 50  0000 C CNN
F 2 "" H 2100 1500 50  0001 C CNN
F 3 "" H 2100 1500 50  0001 C CNN
	1    2100 1500
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR0109
U 1 1 5FEAC0F7
P 1700 1150
F 0 "#PWR0109" H 1700 900 50  0001 C CNN
F 1 "GND" H 1705 977 50  0000 C CNN
F 2 "" H 1700 1150 50  0001 C CNN
F 3 "" H 1700 1150 50  0001 C CNN
	1    1700 1150
	1    0    0    -1  
$EndComp
Text GLabel 1150 1450 0    50   Input ~ 0
LOGIC1
$Comp
L Device:R R1
U 1 1 6024937B
P 1700 1450
F 0 "R1" H 1770 1496 50  0000 L CNN
F 1 "10K" H 1770 1405 50  0000 L CNN
F 2 "Resistor_SMD:R_0805_2012Metric" V 1630 1450 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Uniroyal-Elec-0805W8F1002T5E_C17414.pdf" H 1700 1450 50  0001 C CNN
F 4 "C17414" H 1700 1450 50  0001 C CNN "LCSC Part #"
	1    1700 1450
	0    1    1    0   
$EndComp
$Comp
L Transistor_FET:2N7002K NM2
U 1 1 5FDF015C
P 1400 1250
F 0 "NM2" V 1742 1250 50  0000 C CNN
F 1 "AO3400A" V 1651 1250 50  0000 C CNN
F 2 "Package_TO_SOT_SMD:SOT-23" H 1600 1175 50  0001 L CIN
F 3 "https://datasheet.lcsc.com/szlcsc/Alpha-Omega-Semicon-AOS-AO3400A_C20917.pdf" H 1400 1250 50  0001 L CNN
F 4 "C20917" H 1400 1250 50  0001 C CNN "LCSC Part #"
	1    1400 1250
	0    -1   -1   0   
$EndComp
Wire Wire Line
	1700 1150 1600 1150
$Comp
L power:+12V #PWR0112
U 1 1 609F3D74
P 6550 1250
F 0 "#PWR0112" H 6550 1100 50  0001 C CNN
F 1 "+12V" H 6565 1423 50  0000 C CNN
F 2 "" H 6550 1250 50  0001 C CNN
F 3 "" H 6550 1250 50  0001 C CNN
	1    6550 1250
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR0113
U 1 1 609F42D2
P 6550 1550
F 0 "#PWR0113" H 6550 1300 50  0001 C CNN
F 1 "GND" H 6555 1377 50  0000 C CNN
F 2 "" H 6550 1550 50  0001 C CNN
F 3 "" H 6550 1550 50  0001 C CNN
	1    6550 1550
	1    0    0    -1  
$EndComp
Wire Wire Line
	6250 1400 6550 1400
Wire Wire Line
	6550 1400 6550 1250
Wire Wire Line
	6250 1500 6550 1500
Wire Wire Line
	6550 1500 6550 1550
$Comp
L power:+12V #PWR0114
U 1 1 60A1502C
P 8300 1700
F 0 "#PWR0114" H 8300 1550 50  0001 C CNN
F 1 "+12V" H 8315 1873 50  0000 C CNN
F 2 "" H 8300 1700 50  0001 C CNN
F 3 "" H 8300 1700 50  0001 C CNN
	1    8300 1700
	1    0    0    -1  
$EndComp
Wire Wire Line
	8300 1850 8300 1700
$Comp
L power:+12V #PWR0115
U 1 1 60A1983E
P 9150 850
F 0 "#PWR0115" H 9150 700 50  0001 C CNN
F 1 "+12V" H 9165 1023 50  0000 C CNN
F 2 "" H 9150 850 50  0001 C CNN
F 3 "" H 9150 850 50  0001 C CNN
	1    9150 850 
	1    0    0    -1  
$EndComp
$Comp
L power:+12V #PWR0116
U 1 1 60A1A09F
P 9200 1800
F 0 "#PWR0116" H 9200 1650 50  0001 C CNN
F 1 "+12V" H 9215 1973 50  0000 C CNN
F 2 "" H 9200 1800 50  0001 C CNN
F 3 "" H 9200 1800 50  0001 C CNN
	1    9200 1800
	1    0    0    -1  
$EndComp
$Comp
L power:+12V #PWR0117
U 1 1 60A1A524
P 9250 2750
F 0 "#PWR0117" H 9250 2600 50  0001 C CNN
F 1 "+12V" H 9265 2923 50  0000 C CNN
F 2 "" H 9250 2750 50  0001 C CNN
F 3 "" H 9250 2750 50  0001 C CNN
	1    9250 2750
	1    0    0    -1  
$EndComp
Wire Wire Line
	9150 950  9150 850 
Wire Wire Line
	9200 1900 9200 1800
Wire Wire Line
	9250 2850 9250 2750
Text GLabel 10100 4450 0    50   Input ~ 0
MA1
Text GLabel 10100 4550 0    50   Input ~ 0
MA2
Text GLabel 10100 4150 0    50   Input ~ 0
B1
Text GLabel 10100 4050 0    50   Input ~ 0
B2
Text GLabel 7950 3950 2    50   Input ~ 0
MA1
Text GLabel 7950 4050 2    50   Input ~ 0
MA2
Text GLabel 7950 4150 2    50   Input ~ 0
B1
Text GLabel 7950 4250 2    50   Input ~ 0
B2
Text GLabel 4650 4400 0    50   Input ~ 0
EN
Text GLabel 4650 4600 0    50   Input ~ 0
STEP
Text GLabel 5650 4500 2    50   Input ~ 0
DIR
Text GLabel 4650 4300 0    50   Input ~ 0
M0
$Comp
L power:+5V #PWR0120
U 1 1 60AAD4AB
P 5350 3100
F 0 "#PWR0120" H 5350 2950 50  0001 C CNN
F 1 "+5V" H 5365 3273 50  0000 C CNN
F 2 "" H 5350 3100 50  0001 C CNN
F 3 "" H 5350 3100 50  0001 C CNN
	1    5350 3100
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR0121
U 1 1 5FECF4A3
P 5150 5850
F 0 "#PWR0121" H 5150 5600 50  0001 C CNN
F 1 "GND" V 5155 5722 50  0000 R CNN
F 2 "" H 5150 5850 50  0001 C CNN
F 3 "" H 5150 5850 50  0001 C CNN
	1    5150 5850
	1    0    0    -1  
$EndComp
Wire Wire Line
	5250 5400 5250 5550
Wire Wire Line
	5250 5550 5150 5550
Wire Wire Line
	5150 5550 5150 5850
Wire Wire Line
	5150 5550 5150 5400
Connection ~ 5150 5550
Text GLabel 7950 3750 2    50   Input ~ 0
EN
Text GLabel 6550 4150 0    50   Input ~ 0
M0
Text GLabel 6550 4250 0    50   Input ~ 0
M1
Text GLabel 6550 4450 0    50   Input ~ 0
M2
Text GLabel 6550 3850 0    50   Input ~ 0
DIR
Text GLabel 6550 3950 0    50   Input ~ 0
STEP
Wire Wire Line
	1400 1450 1150 1450
Wire Wire Line
	1400 1450 1550 1450
Connection ~ 1400 1450
Wire Wire Line
	1850 1450 2100 1450
Wire Wire Line
	2100 1450 2100 1500
Wire Wire Line
	1200 4200 1450 4200
Wire Wire Line
	1450 4200 1600 4200
Connection ~ 1450 4200
Wire Wire Line
	1900 4200 2150 4200
Wire Wire Line
	2150 4200 2150 4250
$Comp
L power:GND #PWR0123
U 1 1 5FEBF532
P 1700 2600
F 0 "#PWR0123" H 1700 2350 50  0001 C CNN
F 1 "GND" H 1705 2427 50  0000 C CNN
F 2 "" H 1700 2600 50  0001 C CNN
F 3 "" H 1700 2600 50  0001 C CNN
	1    1700 2600
	1    0    0    -1  
$EndComp
Text GLabel 1100 2900 0    50   Input ~ 0
LOGIC2
$Comp
L Device:R R3
U 1 1 602FA589
P 1800 2900
F 0 "R3" H 1870 2946 50  0000 L CNN
F 1 "10K" H 1870 2855 50  0000 L CNN
F 2 "Resistor_SMD:R_0805_2012Metric" V 1730 2900 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Uniroyal-Elec-0805W8F1002T5E_C17414.pdf" H 1800 2900 50  0001 C CNN
F 4 "C17414" H 1800 2900 50  0001 C CNN "LCSC Part #"
	1    1800 2900
	0    1    1    0   
$EndComp
$Comp
L Transistor_FET:2N7002K NM5
U 1 1 602FA57D
P 1400 2700
F 0 "NM5" V 1742 2700 50  0000 C CNN
F 1 "AO3400A" V 1651 2700 50  0000 C CNN
F 2 "Package_TO_SOT_SMD:SOT-23" H 1600 2625 50  0001 L CIN
F 3 "https://datasheet.lcsc.com/szlcsc/Alpha-Omega-Semicon-AOS-AO3400A_C20917.pdf" H 1400 2700 50  0001 L CNN
F 4 "C20917" H 1400 2700 50  0001 C CNN "LCSC Part #"
	1    1400 2700
	0    -1   -1   0   
$EndComp
Wire Wire Line
	1500 2600 1400 2600
Wire Wire Line
	1600 2600 1700 2600
Wire Wire Line
	1100 2900 1400 2900
Wire Wire Line
	1400 2900 1650 2900
Connection ~ 1400 2900
NoConn ~ 4650 3800
NoConn ~ 4650 3900
NoConn ~ 5650 3800
NoConn ~ 5650 3900
NoConn ~ 5650 4200
Text GLabel 6550 4350 0    50   Input ~ 0
RST
Text GLabel 6550 4650 0    50   Input ~ 0
SLP
Text GLabel 4650 4500 0    50   Input ~ 0
SLP
Text GLabel 4650 4000 0    50   Input ~ 0
RST
Text GLabel 4650 4100 0    50   Input ~ 0
M2
Text GLabel 4650 4200 0    50   Input ~ 0
M1
$Comp
L Connector_Generic:Conn_02x06_Odd_Even PINOUT1
U 1 1 60123A5E
P 1750 7000
F 0 "PINOUT1" H 1800 7417 50  0000 C CNN
F 1 "02X06" H 1800 7326 50  0000 C CNN
F 2 "Connector_PinHeader_2.54mm:PinHeader_2x06_P2.54mm_Vertical" H 1750 7000 50  0001 C CNN
F 3 "~" H 1750 7000 50  0001 C CNN
	1    1750 7000
	1    0    0    -1  
$EndComp
Text GLabel 5650 4800 2    50   Input ~ 0
SDA
Text GLabel 5650 4900 2    50   Input ~ 0
SCL
Text GLabel 1550 6800 0    50   Input ~ 0
SDA
Text GLabel 1550 6900 0    50   Input ~ 0
SCL
$Comp
L power:GND #PWR0119
U 1 1 6012CEE5
P 900 7450
F 0 "#PWR0119" H 900 7200 50  0001 C CNN
F 1 "GND" H 905 7277 50  0000 C CNN
F 2 "" H 900 7450 50  0001 C CNN
F 3 "" H 900 7450 50  0001 C CNN
	1    900  7450
	1    0    0    -1  
$EndComp
Wire Wire Line
	1550 7300 900  7300
Wire Wire Line
	900  7300 900  7450
$Comp
L power:+5V #PWR0124
U 1 1 6013286E
P 1300 6900
F 0 "#PWR0124" H 1300 6750 50  0001 C CNN
F 1 "+5V" H 1315 7073 50  0000 C CNN
F 2 "" H 1300 6900 50  0001 C CNN
F 3 "" H 1300 6900 50  0001 C CNN
	1    1300 6900
	1    0    0    -1  
$EndComp
Wire Wire Line
	1300 6900 1300 7200
Wire Wire Line
	1300 7200 1550 7200
Text GLabel 5650 4400 2    50   Input ~ 0
A0
Text GLabel 5650 4600 2    50   Input ~ 0
A2
Text GLabel 5650 5100 2    50   Input ~ 0
A7
Text GLabel 5650 5000 2    50   Input ~ 0
A6
Text GLabel 4650 5100 0    50   Input ~ 0
D13
Text GLabel 2050 7200 2    50   Input ~ 0
D13
Text GLabel 2050 7000 2    50   Input ~ 0
A0
Text GLabel 2050 6900 2    50   Input ~ 0
A2
Text GLabel 1550 7000 0    50   Input ~ 0
A6
$Comp
L power:+3.3V #PWR0125
U 1 1 601761FF
P 5250 3200
F 0 "#PWR0125" H 5250 3050 50  0001 C CNN
F 1 "+3.3V" H 5200 3350 50  0000 C CNN
F 2 "" H 5250 3200 50  0001 C CNN
F 3 "" H 5250 3200 50  0001 C CNN
	1    5250 3200
	1    0    0    -1  
$EndComp
Wire Wire Line
	2400 7100 2050 7100
Wire Wire Line
	2400 7000 2400 7100
$Comp
L power:+3.3V #PWR0126
U 1 1 601803F9
P 2400 7000
F 0 "#PWR0126" H 2400 6850 50  0001 C CNN
F 1 "+3.3V" H 2350 7150 50  0000 C CNN
F 2 "" H 2400 7000 50  0001 C CNN
F 3 "" H 2400 7000 50  0001 C CNN
	1    2400 7000
	1    0    0    -1  
$EndComp
$Comp
L WillsLib:TMC2208_SILENTSTEPSTICK U1
U 1 1 6013547B
P 7250 4050
F 0 "U1" H 7250 4917 50  0000 C CNN
F 1 "TMC2208_SILENTSTEPSTICK" H 7250 4826 50  0000 C CNN
F 2 "Trio:MODULE_TMC2208_SILENTSTEPSTICK" H 7250 4050 50  0001 L BNN
F 3 "" H 7250 4050 50  0001 L BNN
F 4 "N/A" H 7250 4050 50  0001 L BNN "MAXIMUM_PACKAGE_HEIGHT"
F 5 "Manufacturer Recommendations" H 7250 4050 50  0001 L BNN "STANDARD"
F 6 "v11" H 7250 4050 50  0001 L BNN "PARTREV"
F 7 "Trinamic" H 7250 4050 50  0001 L BNN "MANUFACTURER"
	1    7250 4050
	1    0    0    -1  
$EndComp
Wire Wire Line
	8300 2150 8300 2550
Wire Wire Line
	8300 3550 7950 3550
Wire Wire Line
	7950 4750 8200 4750
Wire Wire Line
	8200 4750 8200 5050
Wire Wire Line
	8300 3300 8700 3300
Wire Wire Line
	8700 3300 8700 3450
Wire Wire Line
	8300 3300 8300 3400
Wire Wire Line
	8700 3750 8700 4750
Wire Wire Line
	8700 4750 8200 4750
Connection ~ 8200 4750
NoConn ~ 7950 4550
$Comp
L power:+5V #PWR0127
U 1 1 601CE906
P 8050 3150
F 0 "#PWR0127" H 8050 3000 50  0001 C CNN
F 1 "+5V" H 8065 3323 50  0000 C CNN
F 2 "" H 8050 3150 50  0001 C CNN
F 3 "" H 8050 3150 50  0001 C CNN
	1    8050 3150
	1    0    0    -1  
$EndComp
Wire Wire Line
	7950 3450 8050 3450
Wire Wire Line
	8050 3450 8050 3400
Text GLabel 4650 5000 0    50   Input ~ 0
D12
Text GLabel 2050 7300 2    50   Input ~ 0
D12
Text GLabel 6550 3650 0    50   Input ~ 0
A3
$Comp
L Device:R R7
U 1 1 601571B9
P 8100 5900
F 0 "R7" H 8170 5946 50  0000 L CNN
F 1 "1K" H 8170 5855 50  0000 L CNN
F 2 "Resistor_SMD:R_0805_2012Metric" V 8030 5900 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Uniroyal-Elec-0805W8F1002T5E_C17414.pdf" H 8100 5900 50  0001 C CNN
F 4 "C17513" H 8100 5900 50  0001 C CNN "LCSC Part #"
	1    8100 5900
	0    1    1    0   
$EndComp
Text GLabel 9050 5800 2    50   Input ~ 0
M2
Wire Wire Line
	8550 5900 8400 5900
$Comp
L Connector_Generic:Conn_02x03_Odd_Even J2
U 1 1 6016327E
P 8750 5800
F 0 "J2" H 8800 6117 50  0000 C CNN
F 1 "USELECT" H 8800 6026 50  0000 C CNN
F 2 "Connector_PinHeader_2.54mm:PinHeader_2x03_P2.54mm_Vertical" H 8750 5800 50  0001 C CNN
F 3 "~" H 8750 5800 50  0001 C CNN
	1    8750 5800
	1    0    0    -1  
$EndComp
Wire Wire Line
	8550 5800 8400 5800
Wire Wire Line
	8400 5800 8400 5900
Connection ~ 8400 5900
Wire Wire Line
	8400 5900 8250 5900
Text GLabel 9050 5700 2    50   Input ~ 0
RST
Text GLabel 9050 5900 2    50   Input ~ 0
SLP
Wire Wire Line
	8550 5700 8400 5700
Wire Wire Line
	8400 5700 8400 5800
Connection ~ 8400 5800
Text GLabel 7750 5900 0    50   Input ~ 0
D12
Wire Wire Line
	7950 5900 7750 5900
$Comp
L Device:D_Schottky_Small D1
U 1 1 60206B39
P 8150 3400
F 0 "D1" H 8150 3193 50  0000 C CNN
F 1 "DSMALL" H 8150 3284 50  0000 C CNN
F 2 "Diode_SMD:D_SOD-123" V 8150 3400 50  0001 C CNN
F 3 "~" V 8150 3400 50  0001 C CNN
F 4 "C8598" H 8150 3400 50  0001 C CNN "LCSC Part #"
	1    8150 3400
	-1   0    0    1   
$EndComp
Connection ~ 8050 3400
Wire Wire Line
	8050 3400 8050 3150
Wire Wire Line
	8250 3400 8300 3400
Connection ~ 8300 3400
Wire Wire Line
	8300 3400 8300 3550
$Comp
L Transistor_FET:AO3401A Q1
U 1 1 60317DF7
P 8200 2750
F 0 "Q1" H 7750 3050 50  0000 L CNN
F 1 "AO3401A" H 7750 2900 50  0000 L CNN
F 2 "Package_TO_SOT_SMD:SOT-23" H 8400 2675 50  0001 L CIN
F 3 "http://www.aosmd.com/pdfs/datasheet/AO3401A.pdf" H 8200 2750 50  0001 L CNN
F 4 "C15127" H 8200 2750 50  0001 C CNN "LCSC Part #"
	1    8200 2750
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR0128
U 1 1 60332422
P 7700 2800
F 0 "#PWR0128" H 7700 2550 50  0001 C CNN
F 1 "GND" H 7705 2627 50  0000 C CNN
F 2 "" H 7700 2800 50  0001 C CNN
F 3 "" H 7700 2800 50  0001 C CNN
	1    7700 2800
	1    0    0    -1  
$EndComp
Wire Wire Line
	8300 2950 8300 3300
Connection ~ 8300 3300
Wire Wire Line
	8000 2750 7700 2750
Wire Wire Line
	7700 2750 7700 2800
Wire Wire Line
	4900 3000 5050 3000
Wire Wire Line
	5350 3400 5350 3100
Wire Wire Line
	5250 3200 5250 3400
Wire Wire Line
	5050 3000 5050 3400
$Comp
L power:GND #PWR0129
U 1 1 60364B0B
P 4700 3300
F 0 "#PWR0129" H 4700 3050 50  0001 C CNN
F 1 "GND" H 4705 3127 50  0000 C CNN
F 2 "" H 4700 3300 50  0001 C CNN
F 3 "" H 4700 3300 50  0001 C CNN
	1    4700 3300
	1    0    0    -1  
$EndComp
Wire Wire Line
	4300 3000 4500 3000
$Comp
L Transistor_FET:AO3401A Q2
U 1 1 6034A788
P 4700 3100
F 0 "Q2" V 4650 3300 50  0000 L CNN
F 1 "AO3401A" V 4950 2950 50  0000 L CNN
F 2 "Package_TO_SOT_SMD:SOT-23" H 4900 3025 50  0001 L CIN
F 3 "http://www.aosmd.com/pdfs/datasheet/AO3401A.pdf" H 4700 3100 50  0001 L CNN
F 4 "C15127" H 4700 3100 50  0001 C CNN "LCSC Part #"
	1    4700 3100
	0    -1   -1   0   
$EndComp
$Comp
L power:+12V #PWR0118
U 1 1 60A8805C
P 4300 2550
F 0 "#PWR0118" H 4300 2400 50  0001 C CNN
F 1 "+12V" H 4315 2723 50  0000 C CNN
F 2 "" H 4300 2550 50  0001 C CNN
F 3 "" H 4300 2550 50  0001 C CNN
	1    4300 2550
	1    0    0    -1  
$EndComp
$Comp
L MCU_Module:Arduino_Nano_v2.x A1
U 1 1 5FDB587C
P 5150 4400
F 0 "A1" H 4900 3350 50  0000 R CNN
F 1 "Nano" H 5600 3400 50  0000 R CNN
F 2 "Module:Arduino_Nano" H 5150 4400 50  0001 C CIN
F 3 "https://www.arduino.cc/en/uploads/Main/ArduinoNanoManual23.pdf" H 5150 4400 50  0001 C CNN
	1    5150 4400
	1    0    0    -1  
$EndComp
Wire Wire Line
	4300 2850 4300 3000
$Comp
L Device:Fuse F7
U 1 1 5FE4682B
P 4300 2700
F 0 "F7" V 4103 2700 50  0000 C CNN
F 1 "3A" V 4194 2700 50  0000 C CNN
F 2 "Fuse:Fuse_1206_3216Metric" V 4230 2700 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Shenzhen-lanson-Elec-12H1300C_C182445.pdf" H 4300 2700 50  0001 C CNN
F 4 " C182445" H 4300 2700 50  0001 C CNN "LCSC Part #"
	1    4300 2700
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR0104
U 1 1 60495C6C
P 2200 2950
F 0 "#PWR0104" H 2200 2700 50  0001 C CNN
F 1 "GND" H 2205 2777 50  0000 C CNN
F 2 "" H 2200 2950 50  0001 C CNN
F 3 "" H 2200 2950 50  0001 C CNN
	1    2200 2950
	1    0    0    -1  
$EndComp
Wire Wire Line
	1950 2900 2200 2900
Wire Wire Line
	2200 2900 2200 2950
$Comp
L Transistor_FET:AO3401A Q3
U 1 1 6049970B
P 2500 950
F 0 "Q3" V 2450 1150 50  0000 L CNN
F 1 "AO3401A" V 2750 800 50  0000 L CNN
F 2 "Package_TO_SOT_SMD:SOT-23" H 2700 875 50  0001 L CIN
F 3 "http://www.aosmd.com/pdfs/datasheet/AO3401A.pdf" H 2500 950 50  0001 L CNN
F 4 "C15127" H 2500 950 50  0001 C CNN "LCSC Part #"
	1    2500 950 
	0    1    -1   0   
$EndComp
Wire Wire Line
	2700 850  2850 850 
$Comp
L power:GND #PWR0105
U 1 1 604C20FC
P 2500 1150
F 0 "#PWR0105" H 2500 900 50  0001 C CNN
F 1 "GND" H 2505 977 50  0000 C CNN
F 2 "" H 2500 1150 50  0001 C CNN
F 3 "" H 2500 1150 50  0001 C CNN
	1    2500 1150
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR0106
U 1 1 604ED899
P 9750 1250
F 0 "#PWR0106" H 9750 1000 50  0001 C CNN
F 1 "GND" H 9755 1077 50  0000 C CNN
F 2 "" H 9750 1250 50  0001 C CNN
F 3 "" H 9750 1250 50  0001 C CNN
	1    9750 1250
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR0110
U 1 1 604EDF8C
P 10400 2200
F 0 "#PWR0110" H 10400 1950 50  0001 C CNN
F 1 "GND" H 10405 2027 50  0000 C CNN
F 2 "" H 10400 2200 50  0001 C CNN
F 3 "" H 10400 2200 50  0001 C CNN
	1    10400 2200
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR0111
U 1 1 604EE484
P 10400 3150
F 0 "#PWR0111" H 10400 2900 50  0001 C CNN
F 1 "GND" H 10405 2977 50  0000 C CNN
F 2 "" H 10400 3150 50  0001 C CNN
F 3 "" H 10400 3150 50  0001 C CNN
	1    10400 3150
	1    0    0    -1  
$EndComp
$Comp
L Transistor_FET:AO3401A Q4
U 1 1 60501A36
P 9750 1050
F 0 "Q4" H 9300 1350 50  0000 L CNN
F 1 "AO3401A" H 9300 1200 50  0000 L CNN
F 2 "Package_TO_SOT_SMD:SOT-23" H 9950 975 50  0001 L CIN
F 3 "http://www.aosmd.com/pdfs/datasheet/AO3401A.pdf" H 9750 1050 50  0001 L CNN
F 4 "C15127" H 9750 1050 50  0001 C CNN "LCSC Part #"
	1    9750 1050
	0    -1   -1   0   
$EndComp
$Comp
L Transistor_FET:AO3401A Q5
U 1 1 60504A46
P 9750 2000
F 0 "Q5" H 9300 2300 50  0000 L CNN
F 1 "AO3401A" H 9300 2150 50  0000 L CNN
F 2 "Package_TO_SOT_SMD:SOT-23" H 9950 1925 50  0001 L CIN
F 3 "http://www.aosmd.com/pdfs/datasheet/AO3401A.pdf" H 9750 2000 50  0001 L CNN
F 4 "C15127" H 9750 2000 50  0001 C CNN "LCSC Part #"
	1    9750 2000
	0    -1   -1   0   
$EndComp
$Comp
L Transistor_FET:AO3401A Q7
U 1 1 60505B44
P 9750 2950
F 0 "Q7" H 9300 3250 50  0000 L CNN
F 1 "AO3401A" H 9300 3100 50  0000 L CNN
F 2 "Package_TO_SOT_SMD:SOT-23" H 9950 2875 50  0001 L CIN
F 3 "http://www.aosmd.com/pdfs/datasheet/AO3401A.pdf" H 9750 2950 50  0001 L CNN
F 4 "C15127" H 9750 2950 50  0001 C CNN "LCSC Part #"
	1    9750 2950
	0    -1   -1   0   
$EndComp
$Comp
L power:GND #PWR0122
U 1 1 6050D6DB
P 10400 1250
F 0 "#PWR0122" H 10400 1000 50  0001 C CNN
F 1 "GND" H 10405 1077 50  0000 C CNN
F 2 "" H 10400 1250 50  0001 C CNN
F 3 "" H 10400 1250 50  0001 C CNN
	1    10400 1250
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR0130
U 1 1 6050DA34
P 9750 2200
F 0 "#PWR0130" H 9750 1950 50  0001 C CNN
F 1 "GND" H 9755 2027 50  0000 C CNN
F 2 "" H 9750 2200 50  0001 C CNN
F 3 "" H 9750 2200 50  0001 C CNN
	1    9750 2200
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR0131
U 1 1 6050DE9F
P 9750 3150
F 0 "#PWR0131" H 9750 2900 50  0001 C CNN
F 1 "GND" H 9755 2977 50  0000 C CNN
F 2 "" H 9750 3150 50  0001 C CNN
F 3 "" H 9750 3150 50  0001 C CNN
	1    9750 3150
	1    0    0    -1  
$EndComp
Wire Wire Line
	9150 950  9550 950 
Wire Wire Line
	9950 950  10100 950 
Wire Wire Line
	9200 1900 9550 1900
Wire Wire Line
	9950 1900 10100 1900
Wire Wire Line
	9250 2850 9550 2850
Wire Wire Line
	9950 2850 10100 2850
Wire Wire Line
	2300 850  2000 850 
Wire Wire Line
	1700 850  1200 850 
$Comp
L Device:Fuse F2
U 1 1 6054E89A
P 1850 2300
F 0 "F2" V 1653 2300 50  0000 C CNN
F 1 "3A" V 1744 2300 50  0000 C CNN
F 2 "Fuse:Fuse_1206_3216Metric" V 1780 2300 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Shenzhen-lanson-Elec-12H1300C_C182445.pdf" H 1850 2300 50  0001 C CNN
F 4 " C182445" H 1850 2300 50  0001 C CNN "LCSC Part #"
	1    1850 2300
	0    1    1    0   
$EndComp
$Comp
L power:+12V #PWR0132
U 1 1 6054E8A0
P 2850 2300
F 0 "#PWR0132" H 2850 2150 50  0001 C CNN
F 1 "+12V" H 2865 2473 50  0000 C CNN
F 2 "" H 2850 2300 50  0001 C CNN
F 3 "" H 2850 2300 50  0001 C CNN
	1    2850 2300
	1    0    0    -1  
$EndComp
$Comp
L Transistor_FET:AO3401A Q6
U 1 1 6054E8A6
P 2500 2400
F 0 "Q6" V 2450 2600 50  0000 L CNN
F 1 "AO3401A" V 2750 2250 50  0000 L CNN
F 2 "Package_TO_SOT_SMD:SOT-23" H 2700 2325 50  0001 L CIN
F 3 "http://www.aosmd.com/pdfs/datasheet/AO3401A.pdf" H 2500 2400 50  0001 L CNN
F 4 "C15127" H 2500 2400 50  0001 C CNN "LCSC Part #"
	1    2500 2400
	0    1    -1   0   
$EndComp
Wire Wire Line
	2700 2300 2850 2300
Wire Wire Line
	2300 2300 2000 2300
Wire Wire Line
	1700 2300 1200 2300
$Comp
L Device:Fuse F5
U 1 1 60552598
P 1900 3600
F 0 "F5" V 1703 3600 50  0000 C CNN
F 1 "3A" V 1794 3600 50  0000 C CNN
F 2 "Fuse:Fuse_1206_3216Metric" V 1830 3600 50  0001 C CNN
F 3 "https://datasheet.lcsc.com/szlcsc/Shenzhen-lanson-Elec-12H1300C_C182445.pdf" H 1900 3600 50  0001 C CNN
F 4 " C182445" H 1900 3600 50  0001 C CNN "LCSC Part #"
	1    1900 3600
	0    1    1    0   
$EndComp
$Comp
L power:+12V #PWR0133
U 1 1 6055259E
P 2900 3600
F 0 "#PWR0133" H 2900 3450 50  0001 C CNN
F 1 "+12V" H 2915 3773 50  0000 C CNN
F 2 "" H 2900 3600 50  0001 C CNN
F 3 "" H 2900 3600 50  0001 C CNN
	1    2900 3600
	1    0    0    -1  
$EndComp
$Comp
L Transistor_FET:AO3401A Q8
U 1 1 605525A4
P 2550 3700
F 0 "Q8" V 2500 3900 50  0000 L CNN
F 1 "AO3401A" V 2800 3550 50  0000 L CNN
F 2 "Package_TO_SOT_SMD:SOT-23" H 2750 3625 50  0001 L CIN
F 3 "http://www.aosmd.com/pdfs/datasheet/AO3401A.pdf" H 2550 3700 50  0001 L CNN
F 4 "C15127" H 2550 3700 50  0001 C CNN "LCSC Part #"
	1    2550 3700
	0    1    -1   0   
$EndComp
Wire Wire Line
	2750 3600 2900 3600
Wire Wire Line
	2350 3600 2050 3600
Wire Wire Line
	1750 3600 1250 3600
$Comp
L power:GND #PWR0134
U 1 1 605CC60D
P 2500 2600
F 0 "#PWR0134" H 2500 2350 50  0001 C CNN
F 1 "GND" H 2505 2427 50  0000 C CNN
F 2 "" H 2500 2600 50  0001 C CNN
F 3 "" H 2500 2600 50  0001 C CNN
	1    2500 2600
	1    0    0    -1  
$EndComp
$Comp
L power:GND #PWR0135
U 1 1 605CCC6C
P 2550 3900
F 0 "#PWR0135" H 2550 3650 50  0001 C CNN
F 1 "GND" H 2555 3727 50  0000 C CNN
F 2 "" H 2550 3900 50  0001 C CNN
F 3 "" H 2550 3900 50  0001 C CNN
	1    2550 3900
	1    0    0    -1  
$EndComp
Text GLabel 1550 7100 0    50   Input ~ 0
A7
Text GLabel 7950 4450 2    50   Input ~ 0
A2
Text GLabel 2050 6800 2    50   Input ~ 0
A3
Text GLabel 5650 4700 2    50   Input ~ 0
A3
$EndSCHEMATC

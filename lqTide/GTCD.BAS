Attribute VB_Name = "Module1"
 Public Sub getTIDE(ywDT As String, ywLongi As Double, ywLati As Double, ywElevation As Double, ywCalculateType As String, ywAzimuth As Double)

 
10 '         PROGRAME---GTCD.BAS
20 CLS:  For I = 0 To 4: Print " ": Next I
30 Dim M(11), G(23), X(23), Y(23)
40 DefDbl T
50 For I = 0 To 11: READ M(I): Next I
60 N1 = Mid(ywDT, 1, 4)
'60 INPUT "YEAR FROM"; N1
'70 INPUT "MONTH FROM"; Y1
70 R0 = Mid(ywDT, 5, 2)
'80 INPUT "DAY RFOM"; R0
80 R0 = Mid(ywDT, 7, 2)
'90 INPUT "LATITUDE"; B: WD = B
90 B = ywLati: WD = B
'100 INPUT "LONGITUDE"; L
100 L = ywLongi
'110 INPUT "ELEVATION"; H0
110 H0 = ywElevation
'120 INPUT "SELECTION (G/T/E/V)"; GH$
120 CH$ = ywCalculateType
130 If GH$ = "G" Or GH$ = "g" Or GH$ = "V" Or GH$ = "v" Then GoTo 160
'140 INPUT "AZIMUTH"; A: FW = A
140 A = ywAzimuth: FW = A
160 If GH$ = "G" Or GH$ = "g" Then Z0 = 1: Z = 0: GoTo 200
170 If GH$ = "T" Or GH$ = "t" Then Z0 = 2: Z = 1: GoTo 200
180 If GH$ = "E" Or GH$ = "e" Then Z0 = 3: Z = 1: GoTo 200
190 If GH$ = "V" Or GH$ = "v" Then Z0 = 4: Z = 0
200 TH = 57.29577951: TP = 3.141592654
230 R1% = Int((N1 - 1900) / 4)
240 R2% = Int((N1 - 1600) / 400)
250 R3% = Int((N1 - 1900) / 100)
260 If N1 - 1900 <> 100 * R3% Then GoTo 290
270 If N1 - 1600 = 400 * R2% Then GoTo 310
280 GoTo 320
290 If N1 - 1900 = 4 * R1% Then GoTo 310
300 GoTo 320
310 R1% = R1% - 1: M(1) = M(1) + 1
320 B = B / TH: A = A / TH
330 PA = 1 - 0.00332479 * Sin(B) * Sin(B) + H0 / 6378140#
340 GG = 1 / (1 + 0.0053024 * Sin(B) * Sin(B) - 0.0000059 * Sin(2 * B) * Sin(2 * B))
350 B = B - 0.192424 * Sin(2 * B) / TH
356 M$ = GH$ + Right$(Str$(N1), 2) + ".DAT"
'357 OPEN "O", #1, M$: TIME0$ = TIME$: Y0 = 1
357 Open M For Output As #1: TIME0$ = Time$: Y0 = 1
360 For YU = Y1 - 1 To 11
362 If YU < 9 Then M$ = "0" + Right$(Str$(YU + 1), 1) Else M$ = Right$(Str$(YU + 1), 2)
370 D = 0: For I = 0 To YU: D = D + M(I): Next I: D = D - M(YU)
380 X1 = 0
390 For R = R0 To M(YU): G0 = 0: N0 = 0: E0 = 0
400 T0 = ((N1 - 1900) * 365 + R1% - R3% + R2% + D + R - 1 + 0.5 - 1 / 3#) / 36525#
410 For I = 0 To 23
420 T = T0 + I / 876600#
430 S# = 270.43416 + ((0.000002 * T - 0.00113) * T + 481267.88314) * T
440 X# = S#: GoSub 2020: S = X#
450 H# = 279.69668 + (0.0003 * T + 36000.76892) * T
460 X# = H#: GoSub 2020: H = X#
470 P# = 334.32956 + ((-0.00001 * T - 0.01032) * T + 4069.03403) * T
480 X# = P#: GoSub 2020: P = X#
490 N# = 259.18328 + ((0.000002 * T + 0.00208) * T - 1934.14201) * T
500 X# = N#: GoSub 2020: N = X#
510 PS# = 281.22083 + ((0.000003 * T + 0.00045) * T + 1.71918) * T
520 X# = PS#: GoSub 2020: PS = X#
530 E# = 23.45229 + ((0.0000005 * T - 0.000002) * T - 0.01301) * T
540 X# = E#: GoSub 2020: E = X#
550 CM = 1 + 0.0545 * Cos(S - P) + 0.003 * Cos(2 * S - 2 * P)
560 CM = CM + 0.01 * Cos(S - 2 * H + P) + 0.0082 * Cos(2 * S - 2 * H)
570 CM = CM + 0.0006000001 * Cos(2 * S - 3 * H + PS) + 0.0009 * Cos(3 * S - 2 * H - P)
580 LM = S - 0.0032 * Sin(H - PS) - 0.001 * Sin(2 * H - 2 * P)
590 LM = LM + 0.001 * Sin(S - 3 * H + P + PS) + 0.0222 * Sin(S - 2 * H + P)
600 LM = LM + 0.0007 * Sin(S - H - P + PS) - 0.0006000001 * Sin(S - H)
610 LM = LM + 0.1098 * Sin(S - P) - 0.0005 * Sin(S + H - P - PS)
620 LM = LM + 0.0008 * Sin(2 * S - 3 * H + PS) + 0.0115 * Sin(2 * S - 2 * H)
630 LM = LM + 0.0037 * Sin(2 * S - 2 * P) - 0.002 * Sin(2 * S - 2 * N)
640 LM = LM + 0.0009 * Sin(3 * S - 2 * H - P)
650 BM = -0.0048 * Sin(P - N) - 0.0008 * Sin(2 * H - P - N)
660 BM = BM + 0.003 * Sin(S - 2 * H + N) + 0.0895 * Sin(S - N)
670 BM = BM + 0.001 * Sin(2 * S - 2 * H + P - N) + 0.0049 * Sin(2 * S - P - N)
680 BM = BM + 0.0006000001 * Sin(3 * S - 2 * H - N)
690 CS = 1 + 0.0168 * Cos(H - PS) + 0.0003 * Cos(2 * H - 2 * PS)
700 LS = H + 0.0335 * Sin(H - PS) + 0.0004 * Sin(2 * H - 2 * PS)
710 BS = 0
720 '      * * * * *      * * * * *      * * * * *
730 '      JISUAN   CHIJING   CHIWEI
740 L0 = LM: B0 = BM: GoSub 2070: AAM = A0: DM = D0
750 L0 = LS: B0 = BS: GoSub 2070: AAS = A0: DS = D0
760 TS = I * 15 - 180 - (120 - L) + 15 * (18.64606 + (2400.05126 + 0.00003 * T) * T)
770 TS = TS - AAS * TH: X# = TS: GoSub 2020: TS = X#: TM = TS + AAS - AAM
780 ZM = Sin(B) * Sin(DM) + Cos(B) * Cos(DM) * Cos(TM)
790 ZS = Sin(B) * Sin(DS) + Cos(B) * Cos(DS) * Cos(TS)
800 On Z0 GoTo 830, 880, 990, 1320
810 '      * * * * *      * * * * *      * * * * *
820 '      JISUAN  ZHONGLI  LILUNZHI
830 G = -165.163 * PA * CM ^ 3 * (ZM * ZM - 1! / 3!)
840 G = G - 1.37 * PA * PA * CM ^ 4 * (5 * ZM * ZM - 3) * ZM
850 G(I) = G - 75.849 * PA * CS ^ 3 * (ZS * ZS - 1! / 3!)
860 G0 = G0 + G(I): GoTo 1360
865 '      * * * * *      * * * * *      * * * * *
870 '      JISUAN  DIQINGXIE  LILUNZHI
880 FM = Cos(B) * Sin(DM) - Sin(B) * Cos(DM) * Cos(TM)
890 FS = Cos(B) * Sin(DS) - Sin(B) * Cos(DS) * Cos(TS)
900 NS = (34.833 * PA * GG * CM ^ 3 * ZM + 0.289 * PA * PA * GG * CM ^ 4 * (5 * ZM * ZM - 1)) * FM
910 NS = NS + 15.996 * PA * GG * CS ^ 3 * ZS * FS
920 EW = -34.833 * PA * GG * CM ^ 3 * ZM * Cos(DM) * Sin(TM)
930 EW = EW - 0.289 * PA * PA * GG * CM ^ 4 * Cos(DM) * Sin(TM) * (5 * ZM * ZM - 1)
940 EW = EW - 15.996 * PA * GG * CS ^ 3 * ZS * Cos(DS) * Sin(TS)
950 If A = 0 Then X(I) = NS: Y(I) = EW: GoTo 965
960 X(I) = NS * Cos(A) + EW * Sin(A): Y(I) = -NS * Sin(A) + EW * Cos(A)
965 N0 = N0 + X(I): E0 = E0 + Y(I): GoTo 1360
970 '      * * * * *       * * * * *      * * * * *
980 '      JISUAN  XIANYINGBIAN  LILUNZHI
990 FM = Cos(B) * Sin(DM) - Sin(B) * Cos(DM) * Cos(TM)
1000 FS = Cos(B) * Sin(DS) - Sin(B) * Cos(DS) * Cos(TS)
1010 Z5M = 5 * ZM * ZM - 1
1020 Z5S = 5 * ZS * ZS - 1
1030 Z3M = 3 * ZM * ZM - 1
1040 Z3S = 3 * ZS * ZS - 1
1050 Z53M = (5 * ZM * ZM - 3) * ZM
1060 Z53S = (5 * ZS * ZS - 3) * ZS
1070 SM = Cos(DM) * Sin(TM)
1080 SS = Cos(DS) * Sin(TS)
1130 X = 14.05 * PA * GG * CM ^ 3 * (FM * FM - ZM * ZM) + 17.208 * PA * GG * CM ^ 3 * Z3M
1140 X = X + 0.02 * PA * PA * GG * CM ^ 4 * ZM * (10 * FM * FM - Z5M)
1150 X = X + 0.136 * PA * PA * GG * CM ^ 4 * Z53M
1160 X = X + 6.452 * PA * GG * CS ^ 3 * (FS * FS - ZS * ZS) + 7.903 * PA * GG * CS ^ 3 * Z3S
1170 Y = 14.05 * PA * GG * CM ^ 3 * (SM * SM - ZM * ZM)
1180 Y = Y + 17.208 * PA * GG * CM ^ 3 * Z3M
1190 Y = Y + 0.02 * PA * PA * GG * CM ^ 4 * ZM * (10 * SM * SM - Z5M)
1200 Y = Y + 0.136 * PA * PA * GG * CM ^ 4 * Z53M
1210 Y = Y + 6.452 * PA * GG * CS ^ 3 * (SS * SS - ZS * ZS)
1220 Y = Y + 7.903 * PA * GG * CS ^ 3 * Z3S
1230 If A = 0 Then X(I) = X: Y(I) = Y: GoTo 1290
1240 XY = 28.1 * PA * GG * CM ^ 3 * FM * SM
1250 XY = XY + 0.041 * PA * PA * GG * CM ^ 4 * 10 * ZM * FM
1260 XY = XY + 12.905 * PA * GG * CS ^ 3 * FS * SS
1270 X(I) = X * Cos(A) * Cos(A) + Y * Sin(A) * Sin(A) - XY * Sin(A) * Cos(A)
1280 Y(I) = X * Sin(A) * Sin(A) + Y * Cos(A) * Cos(A) + XY * Sin(A) * Cos(A)
1290 N0 = N0 + X(I): E0 = E0 + Y(I): GoTo 1360
1300 '      * * * * *      * * * * *      * * * * *
1310 '      JISUAN  TIYINGBIAN  LILUNZHI
1320 V = 40.732 * PA * GG * CM ^ 3 * (ZM * ZM - 1! / 3!)
1330 V = V + 0.127 * PA * PA * CM ^ 4 * (5 * ZM * ZM - 3) * ZM
1340 G(I) = V + 18.706 * PA * GG * CS ^ 3 * (ZS * ZS - 1! / 3!)
1350 G0 = G0 + G(I)
1360 Next I
1370 On Z0 GoTo 1400, 1460, 1460, 1400
1380 '      * * * * *      * * * * *      * * * * *
1390 '      YIN    G
1400 G0 = G0 / 24: GS$ = "####.#"
1410 Print Tab(4); N1; "."; YU + 1; "."; R; ".";
1420 Print Tab(27); "RIJUNZHI"; Tab(40); USING; "###.##"; G0
1430 Print #1, USING; "#####"; N1;: Print #1, USING; "###"; YU + 1; R
1435 GoSub 2310: Print " ": GoTo 1550
1440 '      * * * * *      * * * * *      * * * * *
1450 '      YIN   X Y
1460 N0 = N0 / 24
1470 E0 = E0 / 24: GS$ = "###.##"
1480 Print N1; "."; YU + 1; "."; R; ".";
1490 Print Tab(22); "NS     A=";: Print Tab(32); USING; GS$; FW;
1495 Print USING; "&"; Tab(52); "RIJUNZHI";: Print Tab(61); USING; GS$; N0

1500 For I = 0 To 23: G(I) = X(I): Next I
1505 Print #1, USING; "#####"; N1;: Print #1, USING; "###"; YU + 1; R;
     Print #1, Tab(22); "NS     A=";: Print #1, Tab(31); USING; GS$; FW;
     Print #1, USING; "&"; Tab(52); "RIJUNZHI";: Print #1, Tab(61); USING; GS$; N0
1507 GoSub 2310

1510 Print Tab(22); "EW     A=";: Print Tab(32); USING; GS$; FW + 90;
1515 Print USING; "&"; Tab(52); "RIJUNZHI";: Print Tab(61); USING; GS$; E0

1520 For I = 0 To 23: G(I) = Y(I): Next I
1525 Print #1, USING; "#####"; N1;: Print #1, USING; "###"; YU + 1; R;
     Print #1, Tab(22); "EW     A=";: Print #1, Tab(31); USING; GS$; FW + 90;
     Print #1, USING; "&"; Tab(52); "RIJUNZHI";: Print #1, Tab(61); USING; GS$; E0
1527 GoSub 2310: Print " "
1530 '      * * * * *      * * * * *      * * * * *
1540 '      YIN   YIESHI
1550 X1 = X1 + 1
1560 If X1 = 16 / (Z + 1) Then GoTo 1600
1570 If R = M(YU) Then GoTo 1590
1580 GoTo 1640
1590 For I = 1 To 64 - X1 * (Z + 1) * 4: Print " ": Next I
1600 X1 = 0
1610 Print Tab(38); "-"; Y0; "-"; Tab(50); Date$; " "; TIME0$; " "; Time$: Print " ": Print " "
1620 Y0 = Y0 + 1
1630 For I = 0 To 4: Print " ": Next I
1640 Next R: R0 = 1: Next YU
     Print #1, ""
     Print #1, USING; "&"; Tab(15); "B=";: Print #1, WD; "  L="; L; "  H="; H0; "  A="; FW
     Close #1
1650 End
2000 '      * * * * *      * * * * *      * * * * *
2010 '      SUB--1
2020 If Abs(X#) < 360 Then GoTo 2040
2030 X# = X# - Sgn(X#) * Int(Abs(X#) / 360) * 360
2040 X# = X# / TH: Return
2050 '      * * * * *      * * * * *      * * * * *
2060 '      SUB--2
2070 D0 = Cos(B0) * Sin(L0) * Sin(E) + Sin(B0) * Cos(E)
2080 D0 = D0 / Sqr(1 - D0 * D0)
2090 D0 = Atn(D0)
2100 C0 = Cos(B0) * Cos(L0)
2110 S0 = Cos(B0) * Sin(L0) * Cos(E) - Sin(B0) * Sin(E)
2120 If C0 = 0 Then GoTo 2190
2130 A0 = S0 / C0: A0 = Atn(A0)
2140 If A0 < 0 Then GoTo 2240
2150 If S0 < 0 Then GoTo 2170
2160 GoTo 2280
2170 A0 = TP + A0
2180 GoTo 2280
2190 If S0 < 0 Then GoTo 2220
2200 A0 = TP / 2
2210 GoTo 2280
2220 A0 = 3 * TP / 2
2230 GoTo 2280
2240 If S0 < 0 Then GoTo 2270
2250 A0 = TP + A0
2260 GoTo 2280
2270 A0 = 2 * TP + A0
2280 Return
2290 '      * * * * *      * * * * *      * * * * *
2300 '      SUB--3
2310 For I = 0 To 1
2320 For J = 0 To 11
2330 Print #1, USING; GS$; G(I * 12 + J);
2340 Next J: Print #1, " ": Print " ": Next I: Return
2350 '      * * * * *      * * * * *      * * * * *
2410 Data 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
2420 '      * * * * *      * * * * *      * * * * *
     Print #1, USING; "#####"; N1;: Print #1, USING; "###"; YU + 1; R
 End Sub


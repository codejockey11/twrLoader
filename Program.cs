using System;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace twrLoader
{
    class Program
    {
        static Char[] recordType_001_04 = new Char[04];
        static Char[] facilityId_005_04 = new Char[04];

        static Char[] state_063_02 = new Char[02];
        static Char[] city_065_40 = new Char[40];
        static Char[] name_105_50 = new Char[50];
        static Char[] latitude_155_14 = new Char[14];
        static Char[] longitude_180_14 = new Char[14];
        static Char[] fssId_205_04 = new Char[04];
        static Char[] fssName_209_30 = new Char[30];
        static Char[] type_239_12 = new Char[12];
        static Char[] hoursOfOp_251_02 = new Char[02];
        static Char[] hoursOfOpOther_295_45 = new Char[45];
        static Char[] airportId_256_04 = new Char[04];
        static Char[] airportName_260_50 = new Char[50];
        static Char[] radioCall_805_26 = new Char[26];

        static Char[] hoursOfOp_1409_200 = new Char[200];
        static Char[] pilotToMetroService_009_200 = new Char[200];
        static Char[] militaryAircraftCommandPost_209_200 = new Char[200];
        static Char[] hoursOfMilitaryOp_409_200 = new Char[200];
        static Char[] hoursOfOpPriApproachControl_609_200 = new Char[200];
        static Char[] hoursOfOpSecApproachControl_809_200 = new Char[200];
        static Char[] hoursOfOpPriDepartureControl_1009_200 = new Char[200];
        static Char[] hoursOfOpSecDepartureControl_1209_200 = new Char[200];

        static Char[] freq01_009_44 = new Char[44];
        static Char[] freqUsage01_053_50 = new Char[50];
        static Char[] freq02_103_44 = new Char[44];
        static Char[] freqUsage02_147_50 = new Char[50];
        static Char[] freq03_197_44 = new Char[44];
        static Char[] freqUsage03_241_50 = new Char[50];
        static Char[] freq04_291_44 = new Char[44];
        static Char[] freqUsage04_335_50 = new Char[50];
        static Char[] freq05_385_44 = new Char[44];
        static Char[] freqUsage05_429_50 = new Char[50];
        static Char[] freq06_479_44 = new Char[44];
        static Char[] freqUsage06_523_50 = new Char[50];
        static Char[] freq07_573_44 = new Char[44];
        static Char[] freqUsage07_617_50 = new Char[50];
        static Char[] freq08_667_44 = new Char[44];
        static Char[] freqUsage08_711_50 = new Char[50];
        static Char[] freq09_761_44 = new Char[44];
        static Char[] freqUsage09_805_50 = new Char[50];
        static Char[] freq10_855_60 = new Char[60];
        static Char[] freq11_915_60 = new Char[60];
        static Char[] freq12_975_60 = new Char[60];
        static Char[] freq13_1035_60 = new Char[60];
        static Char[] freq14_1095_60 = new Char[60];
        static Char[] freq15_1155_60 = new Char[60];
        static Char[] freq16_1215_60 = new Char[60];
        static Char[] freq17_1275_60 = new Char[60];
        static Char[] freq18_1335_60 = new Char[60];

        static Char[] masterAirportServices_009_100 = new Char[100];

        static Char[] radarPriApproachCall_009_09 = new Char[09];
        static Char[] radarSecApproachCall_018_09 = new Char[09];
        static Char[] radarPriDepartCall_027_09 = new Char[09];
        static Char[] radarSecDepartCall_036_09 = new Char[09];
        static Char[] radarTowerType01_045_10 = new Char[10];
        static Char[] radarTowerHours01_055_200 = new Char[200];
        static Char[] radarTowerType02_255_10 = new Char[10];
        static Char[] radarTowerHours02_265_200 = new Char[200];
        static Char[] radarTowerType03_465_10 = new Char[10];
        static Char[] radarTowerHours03_475_200 = new Char[200];
        static Char[] radarTowerType04_675_10 = new Char[10];
        static Char[] radarTowerHours04_685_200 = new Char[200];

        static Char[] towerRemarkElement_009_005 = new Char[05];
        static Char[] towerRemark_014_800 = new Char[800];

        static Char[] satelliteFreq_009_044 = new Char[44];
        static Char[] satelliteFreqUse_053_050 = new Char[50];
        static Char[] satelliteFacilityId_114_04 = new Char[04];
        static Char[] fssStationId_293_04 = new Char[04];
        static Char[] fssStationName_297_30 = new Char[30];

        static Char[] classB_009_01 = new Char[01];
        static Char[] classC_010_01 = new Char[01];
        static Char[] classD_011_01 = new Char[01];
        static Char[] classE_012_01 = new Char[01];
        static Char[] airspaceHours_013_300 = new Char[300];

        static Char[] atisSerialNbr_009_004 = new Char[04];
        static Char[] atisHours_013_200 = new Char[200];
        static Char[] atisDesc_213_100 = new Char[100];
        static Char[] atisPhone_313_18 = new Char[18];

        static StreamWriter ofileTWR1 = new StreamWriter("twrTower.txt");
        static StreamWriter ofileTWR2 = new StreamWriter("twrHoursOfOp.txt");
        static StreamWriter ofileTWR3 = new StreamWriter("twrFrequency.txt");
        static StreamWriter ofileTWR4 = new StreamWriter("twrServices.txt");
        static StreamWriter ofileTWR5 = new StreamWriter("twrRadars.txt");
        static StreamWriter ofileTWR6 = new StreamWriter("twrRemarks.txt");
        static StreamWriter ofileTWR7 = new StreamWriter("twrSatellite.txt");
        static StreamWriter ofileTWR8 = new StreamWriter("twrAirspace.txt");
        static StreamWriter ofileTWR9 = new StreamWriter("twrAtis.txt");

        static void Main(String[] args)
        {
            String userprofileFolder = Environment.GetEnvironmentVariable("USERPROFILE");
            String[] fileEntries = Directory.GetFiles(userprofileFolder + "\\Downloads\\", "28DaySubscription*.zip");

            ZipArchive archive = ZipFile.OpenRead(fileEntries[0]);
            ZipArchiveEntry entry = archive.GetEntry("TWR.txt");
            entry.ExtractToFile("TWR.txt", true);

            StreamReader file = new StreamReader("TWR.txt");

            String rec = file.ReadLine();

            while (!file.EndOfStream)
            {
                ProcessRecord(rec);

                rec = file.ReadLine();
            }

            ProcessRecord(rec);

            file.Close();

            ofileTWR1.Close();
            ofileTWR2.Close();
            ofileTWR3.Close();
            ofileTWR4.Close();
            ofileTWR5.Close();
            ofileTWR6.Close();
            ofileTWR7.Close();
            ofileTWR8.Close();
            ofileTWR9.Close();
        }

        static void ProcessRecord(String record)
        {
            recordType_001_04 = record.ToCharArray(0, 4);

            String rt = new String(recordType_001_04);

            Int32 r = String.Compare(rt, "TWR1");
            if (r == 0)
            {
                facilityId_005_04 = record.ToCharArray(4, 4);
                String s = new String(facilityId_005_04).Trim();
                ofileTWR1.Write(s);
                ofileTWR1.Write('~');

                state_063_02 = record.ToCharArray(62, 2);
                s = new String(state_063_02).Trim();
                ofileTWR1.Write(s);
                ofileTWR1.Write('~');

                city_065_40 = record.ToCharArray(64, 40);
                s = new String(city_065_40).Trim();
                ofileTWR1.Write(s);
                ofileTWR1.Write('~');

                name_105_50 = record.ToCharArray(104, 50);
                s = new String(name_105_50).Trim();
                ofileTWR1.Write(s);
                ofileTWR1.Write('~');

                latitude_155_14 = record.ToCharArray(154, 14);
                s = new String(latitude_155_14).Trim();
                ofileTWR1.Write(s);
                ofileTWR1.Write('~');

                longitude_180_14 = record.ToCharArray(179, 14);
                s = new String(longitude_180_14).Trim();
                ofileTWR1.Write(s);
                ofileTWR1.Write('~');

                fssId_205_04 = record.ToCharArray(204, 4);
                s = new String(fssId_205_04).Trim();
                ofileTWR1.Write(s);
                ofileTWR1.Write('~');

                fssName_209_30 = record.ToCharArray(208, 30);
                s = new String(fssName_209_30).Trim();
                ofileTWR1.Write(s);
                ofileTWR1.Write('~');

                type_239_12 = record.ToCharArray(238, 12);
                s = new String(type_239_12).Trim();
                ofileTWR1.Write(s);
                ofileTWR1.Write('~');

                hoursOfOp_251_02 = record.ToCharArray(250, 2);
                s = new String(hoursOfOp_251_02).Trim();
                ofileTWR1.Write(s);
                ofileTWR1.Write('~');

                hoursOfOpOther_295_45 = record.ToCharArray(294, 45);
                s = new String(hoursOfOpOther_295_45).Trim();
                ofileTWR1.Write(s);
                ofileTWR1.Write('~');

                airportId_256_04 = record.ToCharArray(255, 4);
                s = new String(airportId_256_04).Trim();
                ofileTWR1.Write(s);
                ofileTWR1.Write('~');

                airportName_260_50 = record.ToCharArray(259, 50);
                s = new String(airportName_260_50).Trim();
                ofileTWR1.Write(s);
                ofileTWR1.Write('~');

                radioCall_805_26 = record.ToCharArray(804, 26);
                s = new String(radioCall_805_26).Trim();
                ofileTWR1.Write(s);
                ofileTWR1.Write(ofileTWR1.NewLine);
            }

            r = String.Compare(rt, "TWR2");
            if (r == 0)
            {
                String s = new String(facilityId_005_04).Trim();
                ofileTWR2.Write(s);
                ofileTWR2.Write('~');

                hoursOfOp_1409_200 = record.ToCharArray(1408, 200);
                s = new String(hoursOfOp_1409_200).Trim();
                ofileTWR2.Write(s);
                ofileTWR2.Write('~');

                pilotToMetroService_009_200 = record.ToCharArray(8, 200);
                s = new String(pilotToMetroService_009_200).Trim();
                ofileTWR2.Write(s);
                ofileTWR2.Write('~');

                militaryAircraftCommandPost_209_200 = record.ToCharArray(208, 200);
                s = new String(militaryAircraftCommandPost_209_200).Trim();
                ofileTWR2.Write(s);
                ofileTWR2.Write('~');

                hoursOfMilitaryOp_409_200 = record.ToCharArray(408, 200);
                s = new String(hoursOfMilitaryOp_409_200).Trim();
                ofileTWR2.Write(s);
                ofileTWR2.Write('~');

                hoursOfOpPriApproachControl_609_200 = record.ToCharArray(608, 200);
                s = new String(hoursOfOpPriApproachControl_609_200).Trim();
                ofileTWR2.Write(s);
                ofileTWR2.Write('~');

                hoursOfOpSecApproachControl_809_200 = record.ToCharArray(808, 200);
                s = new String(hoursOfOpSecApproachControl_809_200).Trim();
                ofileTWR2.Write(s);
                ofileTWR2.Write('~');

                hoursOfOpPriDepartureControl_1009_200 = record.ToCharArray(1008, 200);
                s = new String(hoursOfOpPriDepartureControl_1009_200).Trim();
                ofileTWR2.Write(s);
                ofileTWR2.Write('~');

                hoursOfOpSecDepartureControl_1209_200 = record.ToCharArray(1208, 200);
                s = new String(hoursOfOpSecDepartureControl_1209_200).Trim();
                ofileTWR2.Write(s);
                ofileTWR2.Write(ofileTWR2.NewLine);
            }

            r = String.Compare(rt, "TWR3");
            if (r == 0)
            {
                FormatWriteFrequency(new String(facilityId_005_04).Trim(), new String(record.ToCharArray(8, 44)).Trim(), new String(record.ToCharArray(52, 50)).Trim());

                FormatWriteFrequency(new String(facilityId_005_04).Trim(), new String(record.ToCharArray(102, 44)).Trim(), new String(record.ToCharArray(146, 50)).Trim());

                FormatWriteFrequency(new String(facilityId_005_04).Trim(), new String(record.ToCharArray(196, 44)).Trim(), new String(record.ToCharArray(240, 50)).Trim());

                FormatWriteFrequency(new String(facilityId_005_04).Trim(), new String(record.ToCharArray(290, 44)).Trim(), new String(record.ToCharArray(334, 50)).Trim());

                FormatWriteFrequency(new String(facilityId_005_04).Trim(), new String(record.ToCharArray(384, 44)).Trim(), new String(record.ToCharArray(428, 50)).Trim());

                FormatWriteFrequency(new String(facilityId_005_04).Trim(), new String(record.ToCharArray(478, 44)).Trim(), new String(record.ToCharArray(522, 50)).Trim());

                FormatWriteFrequency(new String(facilityId_005_04).Trim(), new String(record.ToCharArray(572, 44)).Trim(), new String(record.ToCharArray(616, 50)).Trim());

                FormatWriteFrequency(new String(facilityId_005_04).Trim(), new String(record.ToCharArray(666, 44)).Trim(), new String(record.ToCharArray(710, 50)).Trim());

                FormatWriteFrequency(new String(facilityId_005_04).Trim(), new String(record.ToCharArray(760, 44)).Trim(), new String(record.ToCharArray(804, 50)).Trim());

                FormatWriteFrequency(new String(facilityId_005_04).Trim(), new String(record.ToCharArray(760, 44)).Trim(), new String(record.ToCharArray(804, 50)).Trim());

                /*
                freq10_855_60 = record.ToCharArray(854, 60);

                if (freq10_855_60[0] > ' ')
                {
                    String s = new String(facilityId_005_04).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    s = new String(freq10_855_60).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    ofileTWR3.Write("None");
                    ofileTWR3.Write(ofileTWR3.NewLine);
                }

                freq11_915_60 = record.ToCharArray(914, 60);

                if (freq11_915_60[0] > ' ')
                {
                    String s = new String(facilityId_005_04).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    s = new String(freq11_915_60).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    ofileTWR3.Write("None");
                    ofileTWR3.Write(ofileTWR3.NewLine);
                }

                freq12_975_60 = record.ToCharArray(974, 60);

                if (freq12_975_60[0] > ' ')
                {
                    String s = new String(facilityId_005_04).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    s = new String(freq12_975_60).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    ofileTWR3.Write("None");
                    ofileTWR3.Write(ofileTWR3.NewLine);
                }

                freq13_1035_60 = record.ToCharArray(1034, 60);

                if (freq13_1035_60[0] > ' ')
                {
                    String s = new String(facilityId_005_04).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    s = new String(freq13_1035_60).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    ofileTWR3.Write("None");
                    ofileTWR3.Write(ofileTWR3.NewLine);
                }

                freq14_1095_60 = record.ToCharArray(1094, 60);

                if (freq14_1095_60[0] > ' ')
                {
                    String s = new String(facilityId_005_04).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    s = new String(freq14_1095_60).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    ofileTWR3.Write("None");
                    ofileTWR3.Write(ofileTWR3.NewLine);
                }

                freq15_1155_60 = record.ToCharArray(1154, 60);

                if (freq15_1155_60[0] > ' ')
                {
                    String s = new String(facilityId_005_04).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    s = new String(freq15_1155_60).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    ofileTWR3.Write("None");
                    ofileTWR3.Write(ofileTWR3.NewLine);
                }

                freq16_1215_60 = record.ToCharArray(1214, 60);

                if (freq16_1215_60[0] > ' ')
                {
                    String s = new String(facilityId_005_04).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    s = new String(freq16_1215_60).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    ofileTWR3.Write("None");
                    ofileTWR3.Write(ofileTWR3.NewLine);
                }

                freq17_1275_60 = record.ToCharArray(1274, 60);

                if (freq17_1275_60[0] > ' ')
                {
                    String s = new String(facilityId_005_04).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    s = new String(freq17_1275_60).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    ofileTWR3.Write("None");
                    ofileTWR3.Write(ofileTWR3.NewLine);
                }

                freq18_1335_60 = record.ToCharArray(1334, 60);

                if (freq18_1335_60[0] > ' ')
                {
                    String s = new String(facilityId_005_04).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    s = new String(freq18_1335_60).Trim();
                    ofileTWR3.Write(s);
                    ofileTWR3.Write('~');

                    ofileTWR3.Write("None");
                    ofileTWR3.Write(ofileTWR3.NewLine);
                }
                 */
            }

            r = String.Compare(rt, "TWR4");
            if (r == 0)
            {
                String s = new String(facilityId_005_04).Trim();
                ofileTWR4.Write(s);
                ofileTWR4.Write('~');

                masterAirportServices_009_100 = record.ToCharArray(8, 100);
                s = new String(masterAirportServices_009_100).Trim();
                ofileTWR4.Write(s);
                ofileTWR4.Write(ofileTWR4.NewLine);
            }

            r = String.Compare(rt, "TWR5");
            if (r == 0)
            {
                String s = new String(facilityId_005_04).Trim();
                ofileTWR5.Write(s);
                ofileTWR5.Write('~');

                radarPriApproachCall_009_09 = record.ToCharArray(8, 9);
                s = new String(radarPriApproachCall_009_09).Trim();
                ofileTWR5.Write(s);
                ofileTWR5.Write('~');

                radarSecApproachCall_018_09 = record.ToCharArray(17, 9);
                s = new String(radarSecApproachCall_018_09).Trim();
                ofileTWR5.Write(s);
                ofileTWR5.Write('~');

                radarPriDepartCall_027_09 = record.ToCharArray(26, 9);
                s = new String(radarPriDepartCall_027_09).Trim();
                ofileTWR5.Write(s);
                ofileTWR5.Write('~');

                radarSecDepartCall_036_09 = record.ToCharArray(35, 9);
                s = new String(radarSecDepartCall_036_09).Trim();
                ofileTWR5.Write(s);
                ofileTWR5.Write('~');

                radarTowerType01_045_10 = record.ToCharArray(44, 10);
                s = new String(radarTowerType01_045_10).Trim();
                ofileTWR5.Write(s);
                ofileTWR5.Write('~');

                radarTowerHours01_055_200 = record.ToCharArray(54, 200);
                s = new String(radarTowerHours01_055_200).Trim();
                ofileTWR5.Write(s);
                ofileTWR5.Write('~');

                radarTowerType02_255_10 = record.ToCharArray(254, 10);
                s = new String(radarTowerType02_255_10).Trim();
                ofileTWR5.Write(s);
                ofileTWR5.Write('~');

                radarTowerHours02_265_200 = record.ToCharArray(264, 200);
                s = new String(radarTowerHours02_265_200).Trim();
                ofileTWR5.Write(s);
                ofileTWR5.Write('~');

                radarTowerType03_465_10 = record.ToCharArray(464, 10);
                s = new String(radarTowerType03_465_10).Trim();
                ofileTWR5.Write(s);
                ofileTWR5.Write('~');

                radarTowerHours03_475_200 = record.ToCharArray(474, 200);
                s = new String(radarTowerHours03_475_200).Trim();
                ofileTWR5.Write(s);
                ofileTWR5.Write('~');

                radarTowerType04_675_10 = record.ToCharArray(674, 10);
                s = new String(radarTowerType04_675_10).Trim();
                ofileTWR5.Write(s);
                ofileTWR5.Write('~');

                radarTowerHours04_685_200 = record.ToCharArray(684, 200);
                s = new String(radarTowerHours04_685_200).Trim();
                ofileTWR5.Write(s);
                ofileTWR5.Write(ofileTWR5.NewLine);
            }

            r = String.Compare(rt, "TWR6");
            if (r == 0)
            {
                String s = new String(facilityId_005_04).Trim();
                ofileTWR6.Write(s);
                ofileTWR6.Write('~');

                towerRemarkElement_009_005 = record.ToCharArray(8, 5);
                s = new String(towerRemarkElement_009_005).Trim();
                ofileTWR6.Write(s);
                ofileTWR6.Write('~');

                towerRemark_014_800 = record.ToCharArray(13, 800);
                StringBuilder result = new StringBuilder();
                for (Int32 i = 0; i < towerRemark_014_800.Length; i++)
                {
                    Char c = towerRemark_014_800[i];
                    Byte b = (Byte)c;
                    if ((b < 32) || (b > 126))
                    {
                        //result.Append(replaceWith);
                    }
                    else
                    {
                        result.Append(c);
                    }
                }

                s = result.ToString().Trim(); // new String(towerRemark_014_800).Trim();
                ofileTWR6.Write(s);
                ofileTWR6.Write(ofileTWR6.NewLine);
            }

            r = String.Compare(rt, "TWR7");
            if (r == 0)
            {
                String s = new String(facilityId_005_04).Trim();
                ofileTWR7.Write(s);
                ofileTWR7.Write('~');

                satelliteFreq_009_044 = record.ToCharArray(8, 44);
                String[] ss = new String(satelliteFreq_009_044).Trim().Split(';');
                ofileTWR7.Write(ss[0].Trim().PadRight(7, '0'));

                ofileTWR7.Write('~');

                satelliteFreqUse_053_050 = record.ToCharArray(52, 50);
                s = new String(satelliteFreqUse_053_050).Trim();
                ofileTWR7.Write(s);
                if(ss.Length > 1)
                {
                    ofileTWR7.Write(";" + ss[1]);
                }
                ofileTWR7.Write('~');

                satelliteFacilityId_114_04 = record.ToCharArray(113, 4);
                s = new String(satelliteFacilityId_114_04).Trim();
                ofileTWR7.Write(s);
                ofileTWR7.Write('~');

                fssStationId_293_04 = record.ToCharArray(292, 4);
                s = new String(fssStationId_293_04).Trim();
                ofileTWR7.Write(s);
                ofileTWR7.Write('~');

                fssStationName_297_30 = record.ToCharArray(296, 30);
                s = new String(fssStationName_297_30).Trim();
                ofileTWR7.Write(s);
                ofileTWR7.Write(ofileTWR7.NewLine);
            }

            r = String.Compare(rt, "TWR8");
            if (r == 0)
            {
                String s = new String(facilityId_005_04).Trim();
                ofileTWR8.Write(s);
                ofileTWR8.Write('~');

                classB_009_01 = record.ToCharArray(8, 1);
                s = new String(classB_009_01).Trim();
                ofileTWR8.Write(s);
                ofileTWR8.Write('~');

                classC_010_01 = record.ToCharArray(9, 1);
                s = new String(classC_010_01).Trim();
                ofileTWR8.Write(s);
                ofileTWR8.Write('~');

                classD_011_01 = record.ToCharArray(10, 1);
                s = new String(classD_011_01).Trim();
                ofileTWR8.Write(s);
                ofileTWR8.Write('~');

                classE_012_01 = record.ToCharArray(11, 1);
                s = new String(classE_012_01).Trim();
                ofileTWR8.Write(s);
                ofileTWR8.Write('~');

                airspaceHours_013_300 = record.ToCharArray(12, 300);
                s = new String(airspaceHours_013_300).Trim();
                ofileTWR8.Write(s);
                ofileTWR8.Write(ofileTWR8.NewLine);
            }

            r = String.Compare(rt, "TWR9");
            if (r == 0)
            {
                String s = new String(facilityId_005_04).Trim();
                ofileTWR9.Write(s);
                ofileTWR9.Write('~');

                atisSerialNbr_009_004 = record.ToCharArray(8, 4);
                s = new String(atisSerialNbr_009_004).Trim();
                ofileTWR9.Write(s);
                ofileTWR9.Write('~');

                atisHours_013_200 = record.ToCharArray(12, 200);
                s = new String(atisHours_013_200).Trim();
                ofileTWR9.Write(s);
                ofileTWR9.Write('~');

                atisDesc_213_100 = record.ToCharArray(212, 100);
                s = new String(atisDesc_213_100).Trim();
                ofileTWR9.Write(s);
                ofileTWR9.Write('~');

                atisPhone_313_18 = record.ToCharArray(312, 18);
                s = new String(atisPhone_313_18).Trim();
                ofileTWR9.Write(s);
                ofileTWR9.Write(ofileTWR9.NewLine);
            }
        }

        static void FormatWriteFrequency(String facilityId, String freq, String usage)
        {
            if (freq != "")
            {
                ofileTWR3.Write(facilityId);
                ofileTWR3.Write('~');

                String[] s = freq.Split(';');

                if(s[0].Trim().Contains("FM") )
                {
                    s[0] = s[0].Replace("FM", "");

                    String[] sp = s[0].Split('.');

                    if (sp[0].Length < 3)
                    {
                        ofileTWR3.Write(sp[0].Trim().PadLeft(3, '0'));
                        ofileTWR3.Write(".");
                        ofileTWR3.Write(sp[1].Trim().PadRight(3, '0'));
                    }
                }
                else
                {
                    String[] sp = s[0].Split('.');

                    if (sp[0].Length < 3)
                    {
                        ofileTWR3.Write(sp[0].Trim().PadLeft(3, '0'));
                        ofileTWR3.Write(".");
                        ofileTWR3.Write(sp[1].Trim().PadRight(3, '0'));
                    }
                    else
                    {
                        ofileTWR3.Write(s[0].Trim().PadRight(7, '0'));
                    }
                }

                ofileTWR3.Write('~');

                ofileTWR3.Write(usage);

                if(s.Length > 1)
                {
                    ofileTWR3.Write(";" + s[1]);
                }
                ofileTWR3.Write('~');

                ofileTWR3.Write(ofileTWR3.NewLine);
            }

        }
    }
}

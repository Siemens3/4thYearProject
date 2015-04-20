using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReptileManager.Services
{
    public class HealthStatusVariables
    {
        public HealthStatusVariables(int b, int j, int danger, int minor, int dsb, int daysbl, int ss, int sm, int sl, int ds, int dm, int dl, int lb, int lj, int la )
        {
            BabyWeight = b;
            JuvinileWeight = j;
            DangerWeightLoss = danger;
            MinorWeightLoss = minor;
            DaySinceBirth = dsb;
            DaySinceBirthLong = daysbl;
            ShedLong= ss;
            ShedMedium = sm;
            ShedShort = sl;
            DeficationShort = ds;
            DeficationMedium = dm;
            DeficationLong = dl;
            LengthBaby =lb;
            LengthJuv =lj;
            LengthAdult = la;
            
        }
      public  int BabyWeight { get; set; }
      public  int JuvinileWeight { get; set; }
      public int DangerWeightLoss { get; set; }
      public int MinorWeightLoss { get; set; }
      public int DaySinceBirth { get; set; }
      public int DaySinceBirthLong { get; set; }
      public int ShedLong { get; set; }
      public int ShedShort { get; set; }
      public int ShedMedium { get; set; }
      public int DeficationShort { get; set; }
      public int DeficationMedium { get; set; }
      public int DeficationLong { get; set; }
      public int LengthBaby { get; set; }
      public int LengthJuv { get; set; }
      public int LengthAdult { get; set; }
    }
}
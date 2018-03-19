using System;
using System.Numerics;
using PondLibrary.Vendor;

namespace PondLibrary.Utils
{
    public static class Rand
    {
        public static Pcg Rand1D => Pcg.Default;

        // Да, я долбанулся.
        // Потокобезопасное, двумерно-нескореллированное рандомное безумие.
        [ThreadStatic]
        private static PcgExtended rand2D;
        public static PcgExtended Rand2D => rand2D ?? (
                                              rand2D = new PcgExtended(
                                                  PcgSeed.GuidBasedSeed(),
                                                  PcgExtended.ShiftedIncrement,
                                                  1, // 2^1 = 2, это означает, что любые ближайшие 
                                                     // 2 числа будут нескореллированы
                                                  PcgExtended.AdvancePow2
                                              )
                                          );

        public static Vector2 RandomPondPoint()
        {
            return new Vector2(
                Rand2D.NextFloat(Pond.XMin, Pond.XMax),
                Rand2D.NextFloat(Pond.YMin, Pond.YMax)
            );
        }
    }
}

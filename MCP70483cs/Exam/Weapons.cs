using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    public abstract class Weapons
    {
        protected int damage;
        protected int range;

        public virtual int CalculateDamage(int modifier)
        {
            return damage * modifier;
        }

        public abstract bool HadHit(int roll, int threshold);
    }

    public class Sword : Weapons
    {
        private int size;

        public override int CalculateDamage(int modifier)
        {
            return damage * size * modifier;
        }

        public override bool HadHit(int roll, int threshold)
        {
            return roll * size < threshold;
        }

    }
}

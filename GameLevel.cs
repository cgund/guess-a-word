using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessAWord
{
    class GameLevel
    {
        private readonly String name;
        private readonly Int16 minLetters;
        private readonly Int16 maxLetters;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public short MaxLetters
        {
            get
            {
                return maxLetters;
            }
        }

        public short MinLetters
        {
            get
            {
                return minLetters;
            }
        }

        public GameLevel(String name, Int16 minLetters, Int16 maxLetters)
        {
            this.name = name;
            this.minLetters = minLetters;
            this.maxLetters = maxLetters;
        }

        
        public override String ToString()
        {
            return name;
        }

    }
}

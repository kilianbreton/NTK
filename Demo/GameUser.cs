using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK;

namespace Demo
{
    public enum Direction
    {
        LEFT,RIGHT,UP,DOWN
    }


    public class GameUser : NTKUser
    {
        //x,y
        private int[] pos = new int[2];
        private int health = 0;
        private Direction direction;
        private int widthMap;
        private int heightMap;



        public GameUser(string login) : base(login)
        {

        }



    }
}

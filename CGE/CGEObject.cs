/***********************************
 * CGE - Console Graphical Element *
 * Base Object Class               *
 * 03/07/2018                      *
 ***********************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGE
{
    public abstract class CGEObject
    {
       
        private int indiceM = 0;

        private int startPosX = -1;
        private int startPosY = -1;
        private int moreWidth = 0;
        private int center = 0;             //0=non centré || 1=centré
        private int marginLeft = 0;
        private int marginLeftTxt = 0;
        private int marginRightTxt = 0;
        private bool canEsc = false;

        public CGEObject()
        {

        }

        //  public abstract void start(int i);

        public abstract void draw(int i = 0);
        public abstract void stop(bool bad = false);
        public abstract String show();

        /*
        public int MarginLeft { get => marginLeft; set => marginLeft = value; }
        public int MarginLeftTxt { get => marginLeftTxt; set => marginLeftTxt = value; }
        public int IndiceM { get => indiceM; set => indiceM = value; }
        public int StartPosX { get => startPosX; set => startPosX = value; }
        public int MoreWidth { get => moreWidth; set => moreWidth = value; }
        public int Center { get => center; set => center = value; }
        public int MarginRightTxt { get => marginRightTxt; set => marginRightTxt = value; }
        public int StartPosY { get => startPosY; set => startPosY = value; }
        public bool CanEsc { get => canEsc; set => canEsc = value; }*/
    }
}

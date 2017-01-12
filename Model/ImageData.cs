using System;
using System.Collections.Generic;
using System.Text;

namespace MOD.Model
{

    [Serializable]
   public class ImageData
    {
        //private 
       private int height;
       private int width;
       private byte[] data;

       public ImageData()
       {

       }

       public ImageData(int height, int width,byte[] data)
       {
           this.height = height;
           this.width = width;
           this.data = data;
       }


       public int Height
       {
           get { return height;}
           set {
               value = height;
           }
       }
       public int Width
       {
           get { return width; }
           set {
               value = width;
           }
       }

       public byte[] Data {
           get {
               return data;
           }
           set {
               value = data;
           }
       }


    }
}

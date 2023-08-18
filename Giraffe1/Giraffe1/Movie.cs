using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giraffe
{
     class Movie
    {
        public string title;
        public string writer;
        private string rating;

        public Movie(string aTitle, string aWriter, string aRating)
        {
            title=aTitle;
            writer=aWriter;
            Rating=aRating;
        }
        public string Rating
        {
            get { return rating; }
            set {if(value=="G"||value=="PG"||value=="PG-13"||value=="R"){
                    rating = value;
                }else{
                    rating = "NR";
                } 
           ; }
        }
    }
   
}

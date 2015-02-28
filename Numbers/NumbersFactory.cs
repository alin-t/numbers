using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
   public class NumbersFactory
    {
        public static Number CreateOne()
        {
            var representation = new List<List<string>>
                {
                    new List<string>() {"|"},
                    new List<string>() {"|"},
                    new List<string>() {"|"},
                    new List<string>() {"|"}
                };
            return new Number(representation, 1);
        }

        public static Number CreateTwo()
        {
            var representation = new List<List<string>>
                {
                    new List<string>() {"-", "-", "-"},
                    new List<string>() {" ", "_", "|"},
                    new List<string>() {"|", " ", " "},
                    new List<string>() {"-", "-", "-"}
                };
            return new Number(representation, 2);
        }

        public static Number CreateThree()
        {
            var representation = new List<List<string>>
                {
                    new List<string>() {"-", "-", "-"},
                    new List<string>() {" ", "/", " "},
                    new List<string>() {" ", "\\", " "},
                    new List<string>() {"-", "-", " "}
                };
            return new Number(representation, 3);
        }

        public static Number CreateFour()
        {
            var representation = new List<List<string>>
                {
                    new List<string>() {"|", " ", " ", " ", "|"},
                    new List<string>() {"|", "_", "_", "_", "|"},
                    new List<string>() {" ", " ", " ", " ", "|"},
                    new List<string>() {" ", " ", " ", " ", "|"}
                };
            return new Number(representation, 4);    
        }

        public static Number CreateFive()
        {
            var representation = new List<List<string>>
                {
                    new List<string>() {"-", "-", "-", "-", "-"},
                    new List<string>() {"|", "_", "_", "_", " "},
                    new List<string>() {" ", " ", " ", " ", "|"},
                    new List<string>() {"_", "_", "_", "_", "|"}
                };
            return new Number(representation, 5);
        }

        public static List<Number> CreateKnownNumbers()
        {
            return new List<Number>()
                {
                    CreateOne(),
                    CreateTwo(),
                    CreateThree(),
                    CreateFour(),
                    CreateFive()
                };
        }
    }
}

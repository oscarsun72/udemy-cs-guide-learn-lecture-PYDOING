using System;
using System.Collections.Generic;
namespace classdemo03 {
    class Animals {
        protected string _name;
        public Animals(){_name="動物";}
        
        public Animals (string name) {
            _name = name;
        }
        public void speak () {
            Console.WriteLine ("我是{0}", _name);
        }
    }
    class Elephants : Animals {
        public Elephants () {
            _name = "大象";
        }
    }
    class Mouses : Animals {
        public Mouses () { _name = "老鼠"; }
    }

    class Program {
        static void Main (string[] args) {
            List<Animals> animals = new List<Animals> {//須有using System.Collections.Generic;
                new Animals ("動物"),
                new Elephants (),
                new Mouses ()
            };
            foreach (Animals item in animals) {
                item.speak ();
            }
        }
    }
}
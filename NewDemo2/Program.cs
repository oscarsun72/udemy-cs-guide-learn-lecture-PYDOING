using System;

namespace Newdemo2 {
    class Demo {
        int _demo;
        public Demo (int demo) {
            _demo = demo * 3;
        }

        public int demoValue () {
            return _demo;
        }
    }
}
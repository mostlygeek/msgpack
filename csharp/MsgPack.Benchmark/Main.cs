using System;

using MsgPack;
namespace MsgPack.Benchmark
{
    class MainClass
    {
        public static ObjectPacker packer = new ObjectPacker();

        public static void Main(string[] args)
        {
            SimpleClass sc = new SimpleClass();


            DateTime start = System.DateTime.Now;
            int i = 0;
            for (i=0; i < 100000; i++) {
                packer.Pack(sc);
            }
            TimeSpan done = System.DateTime.Now.Subtract(start);
            Console.WriteLine(string.Format("{0} packs took {1}s, {2}/second, ~{3}ms each",
                                            i, done.TotalSeconds,
                                            Math.Round(i/done.TotalSeconds),
                                            done.TotalMilliseconds/i
                                            ));


            start = System.DateTime.Now;
            byte[] bin = packer.Pack(sc);
            for(i=0; i < 100000; i++) {
                packer.Unpack<SimpleClass>(bin);
            }
            done = System.DateTime.Now.Subtract(start);
            Console.WriteLine(string.Format("{0} unpacks took {1}s, {2}/second, ~{3}ms each",
                                            i, done.TotalSeconds,
                                            Math.Round(i/done.TotalSeconds), done.TotalMilliseconds/i));
        }
    }

    public enum Series {
        zero, one, two, three
    };

    public class SimpleClass
    {
        public int a = 10;
        public float b = 1.31f;
        public double c = 1.31;
        public string d = "Hello World";
        public char e = 'A';

        public Series f = Series.three;
        public Series g = Series.two;
        public Series h = Series.one;

        public int[] i = new int[] {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };
    }

}


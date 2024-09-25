namespace ConsoleApp1
{


    class exVar
    {
        int globalVar;//전역변수, 로컬변수. static, 인스턴스 모두 사용 가능
        public void ModuleTest()
        {
            Console.WriteLine(globalVar);
        }
    }

    class Program
    {
        void Main(string[] args)
        {
            exVar obj = new exVar();
            obj.ModuleTest();
        }
    }


}


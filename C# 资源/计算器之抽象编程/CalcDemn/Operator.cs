namespace CalculateDemo
{
    abstract class Operator
    {
        public decimal Left { get; set; }
        public decimal Right { get; set; }
        public abstract decimal Calc();
    }
        class AddOperator : Operator
    {
        public override decimal Calc()
        {
            return Left + Right;
        }
    }
    class SubOperator : Operator
    {
        public override decimal Calc()
        {
            return Left - Right;
        }
    }
    class MulOperator : Operator
    {
        public override decimal Calc()
        {
            return Left * Right;
        }
    }
    class DivOperrator : Operator
    {
        public override decimal Calc()
        {
            decimal a= Left / Right;
            return a;
        }
    }
}
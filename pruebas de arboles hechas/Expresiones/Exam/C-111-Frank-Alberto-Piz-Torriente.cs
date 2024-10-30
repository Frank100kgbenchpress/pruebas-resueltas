namespace Exam;

public abstract class Expression
{
    public abstract double Evaluate();
}
public abstract class BinaryExpression : Expression
{
    public Expression Left;
    public Expression Right;

    protected BinaryExpression(Expression left, Expression right)
    {
        Left = left;
        Right = right;
    }
}
#region Expresiones Binarias
public class Sum : BinaryExpression
{
    public Sum(Expression left, Expression right) : base(left, right)
    {
    }

    public override double Evaluate()
    {
        return Left.Evaluate() + Right.Evaluate();
    }
}
public class Sub : BinaryExpression
{
    public Sub(Expression left, Expression right) : base(left, right)
    {
    }

    public override double Evaluate()
    {
        return Left.Evaluate() - Right.Evaluate();
    }
}
public class Mul : BinaryExpression
{
    public Mul(Expression left, Expression right) : base(left, right)
    {
    }

    public override double Evaluate()
    {
        Console.WriteLine(Left.Evaluate());
        Console.WriteLine(Right.Evaluate());
        return Left.Evaluate() * Right.Evaluate();
    }
}
public class Div : BinaryExpression
{
    public Div(Expression left, Expression right) : base(left, right)
    {
    }

    public override double Evaluate()
    {
        if(Right.Evaluate() == 0) throw new Exception("Cant divide by zero");
        return Left.Evaluate() / Right.Evaluate(); 
    }
}
public class Pow : BinaryExpression
{
    public Pow(Expression left, Expression right) : base(left, right)
    {
    }

    public override double Evaluate()
    {
        if(Left.Evaluate() == 0 && Right.Evaluate() == 0) throw new Exception("Invalid Operation " + Left.Evaluate() + " Pow" + Right.Evaluate());
        return Math.Pow(Left.Evaluate() , Right.Evaluate());
    }
}
public class Log : BinaryExpression
{
    public Log(Expression left, Expression right) : base(left, right)
    {
    }

    public override double Evaluate()
    {
        if( Right.Evaluate() < 0) throw new Exception("  log base must be in numbers greater than 0");
        return Math.Log(Right.Evaluate(),Left.Evaluate());
    }
}
#endregion

#region Otras Expresiones
public class Constant : Expression
{
    public double Value { get; }
    public Constant(double value)
    {
        Value = value;
    }
    public override double Evaluate()
    {
        return Value;
    }
}
public class Variable : Expression
{
    public string  VariableName { get; }
    public double Value;
    public Variable(string variableName)
    {
        VariableName = variableName;
    }
    public override double Evaluate()
    {
        if(!Let.context.ContainsKey(VariableName)) throw new Exception("Variable no creada");
        return Let.context[VariableName];
    }
}
public class Let : Expression
{
    public string Variable;
    public Expression Init;
    public Expression Exp;
    public static Dictionary<string,double> context = new();
    public Let(string variable, Expression init, Expression exp)
    {
        Variable = variable;
        Init = init;
        Exp = exp;
    }
    public override double Evaluate()
    {
        double aux = Init.Evaluate();
        bool exists = context.ContainsKey(Variable);
        double oldValue = exists ? context[Variable] : 0;
        context[Variable] = aux;
        double result = Exp.Evaluate();
        if (exists)    context[Variable] = oldValue;
        else    context.Remove(Variable);
        return result;
    }
}
#endregion

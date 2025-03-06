<Query Kind="Program" />

void Main()
{
	var str = "2+3+5-3";
	var expression = new CalculateExpression(str);
	var result = expression.Interpret();

	Console.WriteLine("{0} = {1} ", str, result);
}

abstract class Expression
{
	public abstract int Interpret();
}

// Nonterminal expression
class CalculateExpression : Expression
{
	private string context;

	public CalculateExpression(string context)
	{
		this.context = context;
	}

	public override int Interpret() => ResolveExpression(context).Interpret();

	private Expression ResolveExpression(string context)
	{
		if (context.Contains("+"))
		{
			var operands = context.Split('+', 2);
			return new AddExpression(new CalculateExpression(operands[0]), new CalculateExpression(operands[1]));
		}

		if (context.Contains("-"))
		{
			var operands = context.Split('-', 2);
			return new SubtractExpression(new CalculateExpression(operands[0]), new CalculateExpression(operands[1]));
		}

		return new OperandExpression(context);
	}
}

// Terminal expression
class OperandExpression : Expression
{
	private string operand;
	public OperandExpression(string operand)
	{
		this.operand = operand;
	}

	public override int Interpret() => int.Parse(operand);

}

// Nonterminal expression
class AddExpression : Expression
{
	private Expression left;
	private Expression right;

	public AddExpression(Expression left, Expression right)
	{
		this.left = left;
		this.right = right;
	}

	public override int Interpret() => left.Interpret() + right.Interpret();
}

// Nonterminal expression
class SubtractExpression : Expression
{
	private Expression left;
	private Expression right;

	public SubtractExpression(Expression left, Expression right)
	{
		this.left = left;
		this.right = right;
	}

	public override int Interpret() => left.Interpret() - right.Interpret();
}
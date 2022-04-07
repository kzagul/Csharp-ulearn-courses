namespace Inheritance.Geometry.Visitor
{
    public static class BodyExtensions
    {
        public static TResult TryAcceptVisitor<TResult>(this Body body, dynamic visitor)
        {
            // Это нужно, чтобы компилятор не возражал против вызова ещё не добавленного метода Accept
            dynamic dynamicBody = body;
            return (TResult)dynamicBody.Accept(visitor);
        }
    }
}
using OfficePlanApi.Domain.Exceptions;
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace OfficePlanApi.Domain.Helpers
{
    /// <summary>
    /// Provides utilities for evaluating clauses and taking actions if those conditions are not met. By default, behavior is to throw argument exceptions.
    /// </summary>
    [DebuggerStepThrough]
    public static class LogicalGuard
    {
        /// <summary>
        /// This function will evaluate the passed in expression and call the passed in onError action
        /// if the expression evaluates to false
        /// </summary>
        public static void ExpectTrue(Expression<Func<bool>> expression, Action onError)
        {
            if (expression.Compile()())
            {
                return;
            }

            onError();
        }

        /// <summary>
        /// This function will evaluate the passed in expression and call the passed in onError action
        /// if the expression evaluates to false
        /// </summary>
        public static void ExpectTrue(Expression<Func<bool>> expression, Action<Expression<Func<bool>>> onError)
        {
            if (expression.Compile()())
            {
                return;
            }

            onError(expression);
        }

        /// <summary>
        /// This function will evaluate the passed in expression and will throw an invalid argument exception if the
        /// expression does not evaluate to true.  If the expression matches the form LogicalGuard.ExpectTrue( ()=> x != false),
        /// the name of the parameter along with the failing expectation will be indicated in the exception.
        /// </summary>
        public static void ExpectTrue(
            Expression<Func<bool>> expression,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            ExpectIsNotReferenceNull(() => expression);

            var act = new Action(() => CreateException(expression.Body, memberName));
            ExpectTrue(expression, act);
        }

        /// <summary>
        /// This function will evaluate the expression and will cause an agumentexception to be call if you do not
        /// meet the expectation.  The form the function expects is LogicalGuard.ExpectArgumentIsNotNullOrEmpty( ()=> someProp);
        /// </summary>
        /// <param name="expression">
        /// if the expression is in the form x.prop where x is the this pointer the exception will indicated the failing
        /// property
        /// </param>
        public static void ExpectArgumentIsNotNullOrEmpty(Expression<Func<string>> expression)
        {
            var errorAct = new Action(() =>
            {
                var member = expression.Body as MemberExpression;

                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if (member == null || member.Member == null)
                {
                    throw new ArgumentException();
                }
                throw new ArgumentException("Parameter " + member.Member.Name + " is null or empty");
            });
            ExpectIsNotNullOrEmpty(expression, errorAct);
        }

        public static void ExpectArgumentIsNotNullOrEmpty(string value, string argumentName)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return;
            }

            throw new ArgumentException($"Parameter {argumentName} is null or empty");
        }

        /// <summary>
        /// This function will evaluate the expression and will call the passed in onErroaction if the expression evaluates to
        /// false
        /// </summary>
        public static void ExpectIsNotNullOrEmpty(Expression<Func<string>> expression, Action<Expression<Func<string>>> onError)
        {
            if (!string.IsNullOrEmpty(expression.Compile()()))
            {
                return;
            }

            onError(expression);
        }

        /// <summary>
        /// This function will evaluate the expression and will call the passed in onErroaction if the expression evaluates to
        /// false
        /// </summary>
        public static void ExpectIsNotNullOrEmpty(Expression<Func<string>> expression, Action onError)
        {
            if (!string.IsNullOrEmpty(expression.Compile()()))
            {
                return;
            }

            onError();
        }

        /// <summary>
        /// This function checks that the argument is not null
        /// </summary>
        /// <param name="expresion">This expression should be in the form ()=>x where x is an argument to the caller function</param>
        /// <param name="memberName">optional and will be supplied by the complier </param>
        public static void ExpectArgumentIsNotNull(
            Expression<Func<object>> expresion,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Action<string> onError = fnName =>
            {
                var paramExp = expresion.Body as MemberExpression;
                Debug.Assert(paramExp != null, "Use only argument expressions in the form of ()=>x");
                throw new ArgumentException(string.Format("Argument {0} of function {1} is null", paramExp.Member.Name, memberName));
            };

            ExpectIsNotNull(expresion, onError);
        }

        public static void ExpectArgumentIsNotNull(
            object argumentValue,
            string argumentName,
            [CallerMemberName] string memberName = "")
        {
            if (argumentValue != null)
            {
                return;
            }

            throw new ArgumentException($"Argument {argumentName} of function '{memberName}' is null");
        }

        /// <summary>
        /// This function checks that the value is not null
        /// </summary>
        /// <param name="expresion">This expression should be in the form ()=>x where x is a variable</param>
        /// <param name="memberName">optional and will be supplied by the complier </param>
        public static void ExpectValueIsNotNull(
            Expression<Func<object>> expresion,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Action<string> onError = fnName =>
            {
                var paramExp = expresion.Body as MemberExpression;
                Debug.Assert(paramExp != null, "Use only argument expressions in the form of ()=>x");
                throw new UnexpectedNullValueException(string.Format("Value of '{0}' variable in function '{1}' is null", paramExp.Member.Name, memberName));
            };

            ExpectIsNotNull(expresion, onError);
        }

        public static void ExpectValueIsNotNull(
            object value,
            string variableName,
            [CallerMemberName] string memberName = "")
        {
            if (value != null)
            {
                return;
            }

            throw new UnexpectedNullValueException($"Value of {variableName} variable in function '{memberName}' is null");
        }

        #region Helpers

        /// <summary>
        /// Make sure object is not a null reference
        /// </summary>
        private static void ExpectIsNotReferenceNull(Expression<Func<object>> expression)
        {
            var errorAct = new Action(() =>
            {
                var member = expression.Body as MemberExpression;

                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if (member == null || member.Member == null)
                {
                    throw new ArgumentException();
                }
                throw new ArgumentException("Parameter of " + member.Member.Name + " is null or empty");
            });
            ExpectIsNotReferenceNull(expression, errorAct);
        }

        /// <summary>
        /// Make sure object is not a null reference, provide error action
        /// </summary>
        private static void ExpectIsNotReferenceNull(Expression<Func<object>> expression, Action onError)
        {
            if (!ReferenceEquals(null, expression.Compile()()))
            {
                return;
            }

            onError();
        }

        /// <summary>
        /// This function allows dynamic method binding to the most appropriate type
        /// </summary>
        private static void CreateException(dynamic expression, string memberName)
        {
            BuildExecptionMessage(expression, memberName);
        }

        private static void BuildExecptionMessage(Expression expression, string memberName)
        {
            throw new ArgumentException(string.Format("function Expectation of {0} failed in function {1}", expression, memberName));
        }

        private static void BuildExecptionMessage(BinaryExpression body, string memberName)
        {
            MemberExpression member = null;
            string expectation = null;

            if (body != null)
            {
                member = body.Left as MemberExpression;
            }

            // ReSharper disable once PossibleNullReferenceException
            var rightce = body.Right as ConstantExpression;
            if (rightce != null)
            {
                expectation = rightce.ToString();
            }

            var rightme = body.Right as MemberExpression;
            if (rightme != null)
            {
                expectation = rightme.Member.Name;
            }

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            throw new ArgumentException(string.Format(
                "parameter {0} Did not meet expectation of {1} {2} in function {3}",
                member.Member.Name,
                body.NodeType,
                expectation ?? "Unknown",
                memberName));
        }

        private static void ExpectIsNotNull(
            Expression<Func<object>> expresion,
            Action<string> onError,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var lambda = expresion.Compile();
            if (lambda() != null)
            {
                return;
            }

            onError(memberName);
        }

        #endregion
    }
}

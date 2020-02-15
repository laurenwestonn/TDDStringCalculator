using System;
using System.Linq;

namespace PasswordVerifier
{

    public class PasswordVerifier
    {
        private readonly IVerifier verifier;

        public PasswordVerifier(IVerifier _verifier)
        {
            verifier = _verifier;
        }

        public bool Verify(string input)
        {
            return verifier.Verify(input);
        }
    }
    

    public interface IVerifier
    {
        bool Verify(string input);
    }

    public class CombineVerifiers: IVerifier
    {
        readonly IVerifier[] verifiers;
        public CombineVerifiers(IVerifier[] _verifiers)
        {
            verifiers = _verifiers;
        }

        public bool Verify(string input)
        {
            foreach(IVerifier verifier in verifiers)
            {
                if (!verifier.Verify(input))
                    return false;
            }
            return true;
        }
    }

    public class NoLongerThanVerifier: IVerifier
    {
        readonly int length;
        public NoLongerThanVerifier(int _length)
        {
            length = _length;
        }
        public bool Verify(string input)
        {
            return input.Length > length;
        }
    }

    public class NotNullVerifier: IVerifier
    {
        public bool Verify(string input)
        {
            return input != null;
        }
    }

    public class AtLeastOneUpperCaseVerifier : IVerifier
    {
        public bool Verify(string input)
        {
            return input.ToLower() != input;
        }
    }

    public class AtLeastOneLowerCaseVerifier : IVerifier
    {
        public bool Verify(string input)
        {
            return input.ToUpper() != input;
        }
    }

    public class AtLeastOneNumberVerifier : IVerifier
    {
        public bool Verify(string input)
        {
            char[] chars = input.ToCharArray();
            return chars.Any(ch => Char.IsNumber(ch));
        }
    }
}

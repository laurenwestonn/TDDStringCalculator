using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

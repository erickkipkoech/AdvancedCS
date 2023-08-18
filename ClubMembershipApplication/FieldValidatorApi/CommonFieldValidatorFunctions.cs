using System.Text.RegularExpressions;

namespace FieldValidatorApi
{

    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);
    public delegate bool PatternMatchValidDel(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);

    public class CommonFieldValidatorFunctions
    {
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLengthValidDel _stringLengthValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternMatchValidDel _PatternMatchValidDel = null;
        private static CompareFieldsValidDel _compareFieldsValidDel = null;

        //public properties to be accessed only(readonly)
        public static RequiredValidDel RequiredFieldValidDel
        {
            get
            {
                if (_requiredValidDel == null)
                
                    _requiredValidDel = new RequiredValidDel(RequiredFieldValid);
                
                    return _requiredValidDel;
                
            }
        }

        public static StringLengthValidDel StringLengthFieldValidDel
        {
            get 
            {
                if(_stringLengthValidDel == null)
                    _stringLengthValidDel=new StringLengthValidDel(StringFieldLengthValid);
                return _stringLengthValidDel;
            }
        }
        public static DateValidDel DateFieldValidDel
        {
            get
            {
                if(_dateValidDel == null)
                    _dateValidDel=new DateValidDel(DateFieldValid);
                return _dateValidDel;
            }
        }
        public static PatternMatchValidDel PatternMatchValidDel
        {
            get
            {
                if (_PatternMatchValidDel == null)
                    _PatternMatchValidDel = new PatternMatchValidDel(FieldPatternValid);
                return _PatternMatchValidDel;

            }
        }
        public static CompareFieldsValidDel FieldsCompareValidDel
        {
            get
            {
                if(_compareFieldsValidDel == null)
                    _compareFieldsValidDel = new CompareFieldsValidDel(FieldComparisonPattern);
                return _compareFieldsValidDel;
            }
        }

        //Methods for implementing delegate functions
        private static bool RequiredFieldValid(string fieldVal)
        {
            if(!string.IsNullOrEmpty(fieldVal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool StringFieldLengthValid(string fieldVal, int min, int max)
        {
            if(fieldVal.Length>=min && fieldVal.Length <= max)
            {
                return true;
            }
            else { return false;}
        } 
        private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
        {
            if(DateTime.TryParse(dateTime,out validDateTime))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool FieldPatternValid(string fieldVal,string regularExpressionPattern)
        {
            Regex regex = new Regex(regularExpressionPattern);
            if(regex.IsMatch(fieldVal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool FieldComparisonPattern(string field1,string field2)
        {
            if (field1.Equals(field2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
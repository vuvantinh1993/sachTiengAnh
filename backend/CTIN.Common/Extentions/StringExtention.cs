using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace CTIN.Common.Extentions
{
    public static class StringExtention
    {
        public static string ToUnSign(this string s, char replaceSpace = '-', bool lower = true)
        {
            if (s == null)
            {
                s = "";
            }
            s = Regex.Replace(s, @"[^\w\d]", " "); //xoá hết ký tự đặc biệt
            s = Regex.Replace(s, @"\s+", " "); //xoá nhiều khoảng trắng liền nhau
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            string result = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            if (replaceSpace != ' ')
            {
                result = result.Replace(' ', replaceSpace);
            }
            if (lower)
            {
                result = result.ToLower();
            }
            return result;
        }

        public static string Format(this string source, object param)
        {
            var jData = JObject.FromObject(param);
            var n = jData.Properties().Count();
            var lstValue = new object[n];
            var i = 0;
            foreach (var item in jData)
            {
                var name = item.Key;
                var value = item.Value;
                source = source.Replace(name, i.ToString());
                lstValue[i] = value;
                i++;
            }
            return string.Format(source, lstValue);
        }

        public static string FirstCharToUpper(this string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }

        public static string FirstCharToLoower(this string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToLower() + String.Join("", input.Skip(1));
        }

        public static bool HasValue(this string s)
        {
            return !string.IsNullOrEmpty(s);
        }

        public static DateTime? ToDate(this string s, string fomat = "dd/MM/yyyy")
        {
            DateTime result;
            if (DateTime.TryParseExact(s, fomat, null, System.Globalization.DateTimeStyles.None, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public static bool ValidDate(this string s, string fomat = "dd/MM/yyyy")
        {
            DateTime result;
            if (DateTime.TryParseExact(s, fomat, null, System.Globalization.DateTimeStyles.None, out result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidEmail(this string s)
        {
            try
            {
                var check = new MailAddress(s);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Hoàm bỏ dấu
        /// </summary>
        /// <param name="str"> Là chuỗi string có dấu truyền vào</param>
        /// <returns> Trả lại chuỗi string bỏ dấu</returns>
        public static string NonUnicode(this string str)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ","đ",
                                            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
                                            "í","ì","ỉ","ĩ","ị",
                                            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
                                            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
                                            "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a","d",
                                            "e","e","e","e","e","e","e","e","e","e","e",
                                            "i","i","i","i","i",
                                            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
                                            "u","u","u","u","u","u","u","u","u","u","u",
                                            "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                str = str.Replace(arr1[i], arr2[i]);
                str = str.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return str;
        }
    }
}

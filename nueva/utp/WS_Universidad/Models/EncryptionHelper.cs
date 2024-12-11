using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WS_Universidad.Models
{

    public class EncryptionHelper
    {

        public static int[] ASCII_DEC = { 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51,
            52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78,
            79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104,
            105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125,
            126, 128, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 140, 142, 145, 146, 147, 148, 149, 150, 151,
            152, 153, 154, 155, 156, 158, 159, 161, 162, 163, 164, 165, 166, 167, 168, 169, 170, 171, 172, 174, 175,
            176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196,
            197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 210, 211, 212, 213, 214, 215, 216, 217,
            218, 219, 220, 221, 222, 223, 224, 225, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238,
            239, 240, 241, 242, 243, 244, 245, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255 };


 

        public static char[] ASCII_CHAR = { '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.',
            '/', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ':', ';', '<', '=', '>', '?', '@', 'A', 'B', 'C',
            'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
            'Y', 'Z', '[', '\\', ']', '^', '_', '`', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
            'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '{', '|', '}', '~'

    };



        public static int convertChar2Ascii(char caracter)
        {
            for (int i = 0; i < ASCII_CHAR.Length; i++)
            {
                if (ASCII_CHAR[i] == caracter)
                {
                    return ASCII_DEC[i];
                }
            }

            return (int)caracter;
        }

        public static char convertAscii2Char(int ascii)
        {
            for (int i = 0; i < ASCII_DEC.Length; i++)
            {
                if (ASCII_DEC[i] == ascii)
                {
                    return ASCII_CHAR[i];
                }
            }
            return (char)ascii;
        }

        public static string EncryptString(string texto)
        {
            String desencriptado = null;

            if (texto != null && !texto.Equals(""))
            {

                desencriptado = "";
                // Contador que sirve para agregar valor al ascii generado
                // por cada caracter del texto
                int plus = 1;

                for (int i = 0; i < texto.Length; i++)
                {
                    char caracter = texto[i];

                    int ascii = convertChar2Ascii(caracter) + plus;

                    desencriptado = desencriptado + convertAscii2Char(ascii);

                    plus++;
                }

                return desencriptado;
            }
            return null;
        }

        public static string DecryptString(string password)
        {

            String encriptado = null;

            if (password != null && !password.Equals(""))
            {

                encriptado = "";
                int minus = 1;

                for (int i = 0; i < password.Length; i++)
                {
                    char caracter = password[i];

                    int ascii = convertChar2Ascii(caracter) - minus;
                    encriptado = encriptado + convertAscii2Char(ascii);

                    minus++;
                }

                return encriptado;
            }
            return null;

        }
}
}
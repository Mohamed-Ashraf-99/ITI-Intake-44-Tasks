#include <iostream>
#include "Complex.h"

using namespace std;

Complex::Complex(int _real, int _imgl){
    real = _real;
    imgl = _imgl;
}
Complex::Complex(Complex &OldS){
    real = OldS.real;
    imgl = OldS.imgl;
}
Complex::~Complex()
{}

int Complex::getReal(){
    return this->real;
}
int Complex::getImgl(){
    return this->imgl;
}
//Operator Overloading

// 1-) Plus Operator
const Complex Complex::operator+(const Complex &right)
{
    Complex result(real + right.real, imgl + right.imgl);
    return result;
}

// 2-) Plus Operator
const Complex Complex::operator-(const Complex &right)
{
    Complex result(real - right.real, imgl - right.imgl);
    return result;
}

// 3-) Multiplication Operator
const Complex Complex::operator*(const Complex &right)
{
    Complex result(real * right.real, imgl * right.imgl);
    return result;
}

// 4-) Division Operator
const Complex Complex::operator/(const Complex &right)
{
    Complex result(real / right.real, imgl / right.imgl);
    return result;
}

// 5-) Object + int
const Complex Complex::operator+(int right)
{
    Complex result(real + right , imgl);
    return result;
}

// 6-) Object - int
const Complex Complex::operator-(int right)
{
    Complex result(real - right , imgl);
    return result;
}

// 7-) Object * int
const Complex Complex::operator*(int right)
{
    Complex result(real * right , imgl);
    return result;
}

// 8-) Object / int
const Complex Complex::operator/(int right)
{
    Complex result(real / right , imgl);
    return result;
}

// 9-) int + Object
Complex operator+(int left, Complex &right){
    Complex result( left + right.getReal() , right.getImgl());
    return result;
}

// 10-) int - Object
Complex operator-(int left, Complex &right){
    Complex result( left - right.getReal() , right.getImgl());
    return result;
}

// 11-) int * Object
Complex operator*(int left, Complex &right){
    Complex result( left * right.getReal() , right.getImgl());
    return result;
}

// 12-) int / Object
Complex operator/(int left, Complex &right){
    Complex result( left / right.getReal() , right.getImgl());
    return result;
}

// 13-) += Operator
const Complex Complex::operator+=(const Complex &right) {
    real += right.real;
    imgl += right.imgl;
    return *this;
}

// 14-) -= Operator
const Complex Complex::operator-=(const Complex &right) {
    real -= right.real;
    imgl -= right.imgl;
    return *this;
}

// 15-) *= Operator
const Complex Complex::operator*=(const Complex &right) {
    real *= right.real;
    imgl *= right.imgl;
    return *this;
}

// 16-) /= Operator
const Complex Complex::operator/=(const Complex &right) {
    real /= right.real;
    imgl /= right.imgl;
    return *this;
}

// 17-) Postfix ++ Operator
const Complex Complex::operator++() {
    real++;
    return *this;
}

// 18-) Prefix ++ Operator
const Complex Complex::operator++(int){
    Complex temp(*this);
    real++;
    return temp;
}

// 19-) Postfix -- Operator
const Complex Complex::operator--() {
    real--;
    return *this;
}

// 20-) Prefix -- Operator
const Complex Complex::operator--(int){
    Complex temp(*this);
    real--;
    return temp;
}

// 21-)  == Operator
bool Complex::operator==(const Complex &right) {
    return (real == right.real && imgl == right.imgl);
}

// 22-) != Operator
bool Complex::operator!=(const Complex &right) {
    return (real != right.real && imgl != right.imgl);
}

// 23-) > Operator
bool Complex::operator>(const Complex &right){
    return (real > right.real && imgl > right.imgl);
}

// 24-) < Operator
bool Complex::operator<(const Complex &right){
    return (real < right.real && imgl < right.imgl);
}

// 25-) >= Operator
bool Complex::operator>=(const Complex &right){
    return (real >= right.real && imgl >= right.imgl);
}

// 26-) <= Operator
bool Complex::operator<=(const Complex &right){
    return (real <= right.real && imgl <= right.imgl);
}

// 27-Casting int
Complex::operator int(){
    return real;
};

//// 28-) Casting char
Complex::operator char *(){
    string s= to_string(real)+"+"+ to_string(imgl)+"I";
    char* result = new char[s.size()];
    for (int i = 0; i < s.size(); i++) {
        result[i] = s[i];
    }
    result[s.size()]='\0';
    return result;
}


void Complex::print(){
    if(this->imgl == 0)
        cout << this->real << endl;
    else if(this->imgl == 1 && this->real > 0)
        cout << this->real << "+" << "I" << endl;
    else if(this->imgl == -1)
        cout << this->real << "-" << "I" << endl;
    else if(this->real == 0 && this->imgl == 1)
        cout << "I" << endl;
    else if(this->real == 0 && this->imgl == 0)
        cout << "0" << endl;
    else if(this->real == 0 && this->imgl > 0)
        cout << this->imgl << "I" << endl;
    else
        cout << this->real << "+" << this->imgl << "I" << endl;
}


int main() {
    Complex C1(7, 8), C2(3, 4), C3, C4;
    cout << "=========================================" << endl;
    //1-) Plus Operator
    cout << "C1 + C2 = ";
    C3 = C1 + C2;
    C3.print();
    //2-) subtract Operator
    cout << "C1 - C2 = ";
    C3 = C1 - C2;
    C3.print();
    //3-) Multiplication Operator
    cout << "C1 * C2 = ";
    C3 = C1 * C2;
    C3.print();
    //4-) Division Operator
    cout << "C1 / C2 = ";
    C3 = C1 / C2;
    C3.print();
    cout << "=========================================" << endl;
    //5-) Object + int
    cout << "C1 + int = ";
    C3 = C1 + 7;
    C3.print();
    //6-) Object - int
    cout << "C1 - int = ";
    C3 = C1 - 7;
    C3.print();
    //7-) Object * int
    cout << "C1 * int = ";
    C3 = C1 * 7;
    C3.print();
    //8-) Object / int
    cout << "C1 / int = ";
    C3 = C1 / 7;
    C3.print();
    cout << "=========================================" << endl;
    // 9-) int + Object
    cout << "int + C1 = ";
    C3 = 4 + C1;
    C3.print();
    // 10-) int - Object
    cout << "int - C1 = ";
    C3 = 9 - C1;
    C3.print();
    // 11-) int * Object
    cout << "int * C1 = ";
    C3 = 9 * C1;
    C3.print();
    // 12-) int / Object
    cout << "int / C1 = ";
    C3 = 9 / C1;
    C3.print();
    cout << "=========================================" << endl;
    // 13-) += Operator
    cout << "C1 += C2 = ";
    C3 = (C1 += C2);
    C3.print();
    // 14-) -= Operator
    cout << "C1 -= C2 = ";
    C3 = (C1 -= C2);
    C3.print();
    // 15-) *= Operator
    cout << "C1 *= C2 = ";
    C3 = (C1 *= C2);
    C3.print();
    // 16-) /= Operator
    cout << "C1 /= C2 = ";
    C3 = (C1 /= C2);
    C3.print();
    cout << "=========================================" << endl;
    // 17-) Postfix ++ Operator
    cout << "C1++ = ";
    C4 = C1++;
    C4.print();
    // 18-) Prefix ++ Operator
    cout << "++C1 = ";
    C4 = ++C1;
    C4.print();
    // 19-) Postfix -- Operator
    cout << "C1-- = ";
    C4 = C1--;
    C4.print();
    // 20-) Prefix -- Operator
    cout << "--C1 = ";
    C4 = --C1;
    C4.print();
    cout << "=========================================" << endl;
    // 21-)  == Operator
    cout << "C1 == C2 : ";
    C1 == C2 ? cout << "TRUE" << endl : cout << "FALSE" << endl;
    // 22-)  != Operator
    cout << "C1 != C2 : ";
    C1 != C2 ? cout << "TRUE" << endl : cout << "FALSE" << endl;
    // 23-)  > Operator
    cout << "C1 > C2 : ";
    C1 > C2 ? cout << "TRUE" << endl : cout << "FALSE" << endl;
    // 24-)  < Operator
    cout << "C1 < C2 : ";
    C1 < C2 ? cout << "TRUE" << endl : cout << "FALSE" << endl;
    // 25-)  >= Operator
    cout << "C1 >= C2 : ";
    C1 >= C2 ? cout << "TRUE" << endl : cout << "FALSE" << endl;
    // 26-)  <= Operator
    cout << "C1 <= C2 : ";
    C1 <= C2 ? cout << "TRUE" << endl : cout << "FALSE" << endl;
    cout << "=========================================" << endl;
    // 27-) Casting int();
    cout << "(int)C1 = " ;
    cout << (int)C1 << endl;
    // 27-) Casting char*();
    cout << "(char*)C1 = " ;
    cout << (char*)C1 << endl;

    return 0;
}



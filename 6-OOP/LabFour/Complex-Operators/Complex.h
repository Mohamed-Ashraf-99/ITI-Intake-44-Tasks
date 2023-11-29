//
// Created by Mohamed on 11/29/2023.
//

#ifndef COMPLEX_OVER_LOADING_COMPLEX_H
#define COMPLEX_OVER_LOADING_COMPLEX_H
#include "string"


class Complex {
    int real;
    int imgl;
public:
    Complex(int _real = 0, int _imgl = 0);
    Complex(Complex &OldS);
    ~Complex();

    int getReal();
    int getImgl();
    //Operator Overloading

    // 1-) Plus Operator
    const Complex operator+(const Complex &right);
    // 2-) Plus Operator
    const Complex operator-(const Complex &right);
    // 3-) Multiplication Operator
    const Complex operator*(const Complex &right);
    // 4-) Division Operator
    const Complex operator/(const Complex &right);
    // 5-) Object + int
    const Complex operator+(int right);
    // 6-) Object - int
    const Complex operator-(int right);
    // 7-) Object * int
    const Complex operator*(int right);
    // 8-) Object / int
    const Complex operator/(int right);
    // 13-) += Operator
    const Complex operator+=(const Complex &right);
    // 14-) -= Operator
    const Complex operator-=(const Complex &right);
    // 15-) *= Operator
    const Complex operator*=(const Complex &right);
    // 16-) /= Operator
    const Complex operator/=(const Complex &right);
    // 17-) Postfix Operator
    const Complex operator++();
    // 18-) Prefix ++ Operator
    const Complex operator++(int );
    // 19-) Postfix -- Operator
    const Complex operator--();
    // 20-) Prefix -- Operator
    const Complex operator--(int );
    // 21-) == Operator
    bool operator==(const Complex &right);
    // 22-) != Operator
    bool operator!=(const Complex &right);
    // 23-) > Operator
    bool operator>(const Complex &right);
    // 24-) < Operator
    bool operator<(const Complex &right);
    // 25-) >= Operator
    bool operator>=(const Complex &right);
    // 26-) <= Operator
    bool operator<=(const Complex &right);
    // 27-) Casting int
    operator int();
    // 28-) Casting int
    operator char *();
    void print();
};


#endif //COMPLEX_OVER_LOADING_COMPLEX_H

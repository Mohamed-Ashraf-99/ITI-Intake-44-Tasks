#include <iostream>

using namespace std;

class Complex{
    int real;
    int imgl;
public:
    Complex(int _real = 0, int _imgl = 0)
    {
        real = _real;
        imgl = _imgl;
        cout << "Ctor" << endl;
    }
    Complex(Complex &OldS)
    {
        real = OldS.real;
        imgl = OldS.imgl;
        cout << "Copy Ctor" << endl;
    }
    ~Complex()
    {
        cout << "Dest" << endl;
    }

    Complex sum(Complex Right){
        Complex Result;
        Result.real = real + Right.real;
        Result.imgl = imgl + Right.imgl;
        return Result;
    }

       void print(){
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
};
int main()
{

    Complex C1(7, 8), C2(3, 4 ), C3;
    C3 = C1.sum(C2);

    return 0;
}

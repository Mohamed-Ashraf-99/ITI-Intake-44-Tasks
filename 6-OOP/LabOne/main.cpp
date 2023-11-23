#include <iostream>
using namespace std;

class Complex{
    int real;
    int imgl;
public:
    void setReal(int R){
        this->real = R;
    }
    void setImgl(int I){
        this->imgl = I;
    }
    int getReal(){
        return this->real;
    }
    int getImgl(){
        return this->imgl;
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
    Complex sum(Complex c){
        Complex c2;
        c2.setReal(this->real + c.getReal());
        c2.setImgl(this->imgl + c.getImgl());
        return c2;
    }

};

Complex sub(Complex a, Complex b){
    Complex c;
    c.setReal(a.getReal() - b.getReal());
    c.setImgl(a.getImgl() - b.getImgl());
    return c;
}

int main() {
    Complex num1, num2;
    Complex sumTwo, subTwo;

    num1.setReal(0);
    num1.setImgl(0);
    num1.print();
    cout << "====================================" <<endl;

    num1.setReal(0);
    num1.setImgl(5);
    num1.print();
    cout << "====================================" <<endl;

    num1.setReal(0);
    num1.setImgl(1);
    num1.print();
    cout << "====================================" <<endl;

/////////////////////////////////////////
    num1.setReal(5);
    num1.setImgl(10);

    num2.setReal(3);
    num2.setImgl(8);

    sumTwo = num1.sum(num2);
    sumTwo.print();
    cout << "====================================" <<endl;

    subTwo = sub(num1, num2);
    subTwo.print();



    return 0;
}

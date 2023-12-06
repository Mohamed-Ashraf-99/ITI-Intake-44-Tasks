//
// Created by Mohamed on 11/30/2023.
//

#ifndef GEOSHAPE_SQUARE_H
#define GEOSHAPE_SQUARE_H
#include "Rectangle.h"

class Square : protected Rectangle{
public:
    Square(int d1): Rectangle(d1, d1)
    {}
    double getArea(){
        return calcArea();
    }
};


#endif //GEOSHAPE_SQUARE_H

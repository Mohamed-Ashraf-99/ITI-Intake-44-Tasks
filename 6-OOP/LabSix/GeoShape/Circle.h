//
// Created by Mohamed on 11/30/2023.
//

#ifndef GEOSHAPE_CIRCLE_H
#define GEOSHAPE_CIRCLE_H
#include "GeoShape.h"

class Circle : public GeoShape{
public:
    Circle(int r) : GeoShape(r, r)
    {}
    double calcArea(){
        return 3.14 * getDim1() * getDim2();
    }
};


#endif //GEOSHAPE_CIRCLE_H

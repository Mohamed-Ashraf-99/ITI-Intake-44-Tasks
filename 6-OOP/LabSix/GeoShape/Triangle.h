//
// Created by Mohamed on 11/30/2023.
//

#ifndef GEOSHAPE_TRIANGLE_H
#define GEOSHAPE_TRIANGLE_H
#include "GeoShape.h"

class Triangle : public GeoShape {
public:
    Triangle(int d1, int d2) : GeoShape(d1, d2)
    {}
    double calcArea(){
        return 0.5 * getDim1() * getDim2();
    }
};


#endif //GEOSHAPE_TRIANGLE_H

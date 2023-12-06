//
// Created by Mohamed on 11/30/2023.
//

#ifndef GEOSHAPE_RECTANGLE_H
#define GEOSHAPE_RECTANGLE_H
#include "GeoShape.h"


class Rectangle : public GeoShape{
public:
      Rectangle(int d1, int d2) : GeoShape(d1, d2)
      {}

      double calcArea(){
          return getDim1() * getDim2();
      }

};


#endif //GEOSHAPE_RECTANGLE_H

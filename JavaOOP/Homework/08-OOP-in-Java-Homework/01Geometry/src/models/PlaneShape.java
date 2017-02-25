package models;

import contracts.AreaMeasurable;
import contracts.PerimeterMeasurable;

public abstract class PlaneShape extends Shape implements PerimeterMeasurable, AreaMeasurable {
    protected PlaneShape(Vertex2D[] vertices2D) {
        super(vertices2D);
    }
}
package models;

import contracts.AreaMeasurable;
import contracts.VolumeMeasurable;

public abstract class SpaceShape extends Shape implements AreaMeasurable, VolumeMeasurable {
    protected SpaceShape(Vertex3D[] vertices3D) {
        super(vertices3D);
    }
}
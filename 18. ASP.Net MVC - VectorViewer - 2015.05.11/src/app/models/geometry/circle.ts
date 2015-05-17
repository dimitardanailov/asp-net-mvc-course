/// <reference path="Shape.ts"/>

module Models {
	export module Geometry {		
		export class Circle extends Models.Geometry.Shape {
			protected center: Models.Geometry.Point; 
			protected radius: number = 0;
			
			public getCenter(): Models.Geometry.Point {
				return this.center;
			}
			
			public setCenter(point: Models.Geometry.Point) {
				this.center = point;
			}
			
			public getRadius(): number {
				return this.radius;
			}
			
			public setRadius(radius: number) {
				this.radius = radius;
			}
		}
	}
}
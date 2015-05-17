/// <reference path="Shape.ts"/>

module Models {
	export module Geometry {		
		export class Line extends Models.Geometry.Shape {
			protected startPoint: Models.Geometry.Point;
			protected endPoint: Models.Geometry.Point;
			
			public getStartPoint(): Models.Geometry.Point {
				return this.startPoint;
			}
			
			public setStartPoint(point: Models.Geometry.Point) {
				this.startPoint = point;
			}
			
			public getEndPoint(): Models.Geometry.Point {
				return this.endPoint;
			}
			
			public setEndPoint(point: Models.Geometry.Point) {
				this.endPoint = point;
			}
		}
	}
}
/// <reference path="Point.ts"/>

module Models {
	export module Geometry {		
		export class Shape {
			protected scale: number = 1;
			protected position: Models.Geometry.Point;
			
			public getScale(): number {
				return this.scale;
			}
			
			public setScale(scale: number): void {
				this.scale = scale;
			}
			
			public getPosition(): Models.Geometry.Point {
				return this.position;
			}
			
			public setPosition(position: Models.Geometry.Point) {
				this.position = position;
			}
		}
	}
}
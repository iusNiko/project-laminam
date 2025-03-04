shader_type spatial;

varying vec4 pos;

void vertex() {
	pos = VIEW_MATRIX * vec4(VERTEX, 1.0);
	VERTEX.x *= (sin(TIME * 2.3f) + 6.0f) / 7.0f;
	VERTEX.y *= (sin(TIME * 4.5f) + 6.0f) / 7.0f;
	VERTEX.z *= (sin(TIME * 3.8f) + 6.0f) / 7.0f;
}

void fragment() {
	ALBEDO.r = (sin(TIME * 4.7f) + 3.0f + 2.0f * sin(pos.x)) / 6.0f;
	ALBEDO.g = (sin(TIME * 5.3f) + 3.0f + 2.0f * sin(pos.y)) / 6.0f;
	ALBEDO.b = (sin(TIME * 3.6f) + 3.0f + 2.0f * sin(pos.z)) / 6.0f;
}

//void light() {
//	// Called for every pixel for every light affecting the material.
//	// Uncomment to replace the default light processing function with this one.
//}

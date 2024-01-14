#version 460 core

uniform float time;
uniform vec2 resolution;

uniform sampler2D texture0;
uniform sampler2D texture1;

in vec2 texCoord;

out vec4 fragColor;

float GetSign(float Px, float Py, float Ax, float Ay, float Bx, float By)
{
	return (Bx - Ax) * (Py - Ay) - (By - Ay) * (Px - Ax);
}

bool PointIsInRectangle(float x0, float y0, float x1, float y1, 
	float x2, float y2, float x3, float y3, vec2 p)
{
	float p0 = GetSign(p.x, p.y, x0, y0, x1, y1);
	float p1 = GetSign(p.x, p.y, x1, y1, x2, y2);
	float p2 = GetSign(p.x, p.y, x2, y2, x3, y3);
	float p3 = GetSign(p.x, p.y, x3, y3, x0, y0);

	return (p0 < 0 && p1 < 0 && p2 < 0 && p3 < 0) || 
		(p0 > 0 && p1 > 0 && p2 > 0 && p3 > 0);
}

void main()
{
	float x0 = 0.1, y0 = 0.6, 
		x1 = 0.2, y1 = 0.6, 
		x2 = 0.2, y2 = 0.3, 
		x3 = 0.1, y3 = 0.3;
	float x4 = 0.8, y4 = 0.6, 
		x5 = 0.9, y5 = 0.6, 
		x6 = 0.9, y6 = 0.3, 
		x7 = 0.8, y7 = 0.3;

	if (PointIsInRectangle(x0, y0, x1, y1, x2, y2, x3, y3, texCoord))
	{
		fragColor = vec4(1.0, 0.0, 0.0, 1.0);
	}
	else if (PointIsInRectangle(x4, y4, x5, y5, x6, y6, x7, y7, texCoord))
	{
		fragColor = vec4(0.0, 0.0, 1.0, 1.0);
	}
	else 
	{
		vec4 tex1 = texture(texture0, texCoord);
		fragColor = tex1;
	}
}
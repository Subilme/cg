#version 460 core

in vec2 aPosition;
in vec2 aTexCoord;

uniform mat4 projection;

out vec2 texCoord;

void main() 
{
    texCoord = aTexCoord;
    gl_Position = projection * vec4(aPosition, 0.0, 1.0);
}
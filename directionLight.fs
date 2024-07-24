#version 330 core
out vec4 FragColor;

in vec3 vFragPos;  
in vec3 ObjColor;  
in vec3 vNormal;

uniform vec3 direction;
uniform vec3 viewPos;
uniform float shininess;
uniform vec3 lightColor;
uniform float ambientStrength;

void main()
{
    // ambient
    vec3 ambient = ambientStrength * lightColor;
  	
    // diffuse 
    vec3 norm = normalize(vNormal);
    // 平行光不需要计算物体和光源的位置
    vec3 lightDir = normalize(-direction);  

    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = lightColor * diff;
    
    // specular
    vec3 viewDir = normalize(viewPos - vFragPos);
    vec3 reflectDir = reflect(-lightDir, norm);  
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), shininess);
    vec3 specular =  spec * lightColor;
        
    vec3 result = (ambient + diffuse + specular)*ObjColor;
    FragColor = vec4(result, 1.0);
} 
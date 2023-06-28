import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation
import sympy as sp

def Rot(X,Y,Alpha):
    RotX = X*np.cos(Alpha) - Y*np.sin(Alpha)
    RotY = X*np.sin(Alpha) + Y*np.cos(Alpha)
    return RotX, RotY

def Center(x, y):
    dx = sp.diff(x, t)
    dy = sp.diff(y, t)

    ddx = sp.diff(dx, t)
    ddy = sp.diff(dy, t)
    c_x = x - dy * ((dx * dx + dy * dy) / (dx * ddy - ddx * dy))
    c_y = y + dx * ((dx * dx + dy * dy) / (dx * ddy - ddx * dy))

    return c_x, c_y
t = sp.Symbol('t')
r = 2+sp.cos(6*t)
phi = t +1.2*sp.cos(6*t)
x = r*sp.cos(phi)
y = r*sp.sin(phi)
Vx = sp.diff(x,t)
Vy = sp.diff(y,t)

Wx = sp.diff(Vx, t)
Wy = sp.diff(Vy, t)

c_x, c_y = Center(x, y)

F_x = sp.lambdify(t, x)
F_y = sp.lambdify(t, y)
F_Vx = sp.lambdify(t, Vx)
F_Vy = sp.lambdify(t, Vy)
F_c_x = sp.lambdify(t, c_x)
F_c_y = sp.lambdify(t, c_y)
F_Wx = sp.lambdify(t, Wx)
F_Wy = sp.lambdify(t, Wy)

t = np.linspace(0,10,1001)

x = F_x(t)
y = F_y(t)
Vx = F_Vx(t)
Vy = F_Vy(t)
Cx = F_c_x(t)
Cy = F_c_y(t)
Wx = F_Wx(t)
Wy = F_Wy(t)

Alpha_V = np.arctan2(Vy,Vx)

fig = plt.figure(figsize=[10,10])
ax = fig.add_subplot(1,1,1)
ax.axis('equal')
ax.set(xlim=[-12,12],ylim=[-12,12])

k_V = 0.5
k_W = 0.1
k_C = 1
ax.plot(x,y)
P = ax.plot(x[0],y[0],marker='o')[0]

V_line = ax.plot([x[0], x[0]+k_V*Vx[0]],[y[0], y[0]+k_V*Vy[0]],color=[1,0,0])[0]
W_line = ax.plot([x[0], x[0]+k_W*Wx[0]],[y[0], y[0]+k_W*Wy[0]],color=[0,1,0])[0]
C_line = ax.plot([x[0], x[0]+k_C*Cx[0]],[y[0], y[0]+k_C*Cy[0]],color=[0,0,1])[0]

a=0.1
b=0.03
x_arr = np.array([-a, 0, -a])
y_arr = np.array([b, 0, -b])
RotX, RotY = Rot2D(x_arr,y_arr,Alpha_V[0])

V_Arrow = ax.plot(x[0]+k_V*Vx[0] + RotX, y[0]+k_V*Vy[0] + RotY,color=[1,0,0])[0]
W_Arrow = ax.plot(x[0]+k_W*Wx[0] + RotX, y[0]+k_W*Wy[0] + RotY,color=[0,1,0])[0]
C_Arrow = ax.plot(x[0]+k_C*Cx[0] + RotX, y[0]+k_C*Cy[0] + RotY,color=[0,1,0])[0]

def TheMagicOfThtMovement(i):
    P.set_data(x[i],y[i])

    V_line.set_data([x[i], x[i]+k_V*Vx[i]],[y[i], y[i]+k_V*Vy[i]])
    W_line.set_data([x[i], x[i]+k_W*Wx[i]],[y[i], y[i]+k_W*Wy[i]])
    C_line.set_data([x[i], x[i]+k_C*Cx[i]],[y[i], y[i]+k_C*Cy[i]])
    RotX, RotY = Rot2D(x_arr, y_arr, Alpha_V[i])

    V_Arrow.set_data(x[i]+k_V*Vx[i] + RotX, y[i]+k_V*Vy[i] + RotY)
    W_Arrow.set_data(x[i]+k_W*Wx[i] + RotX, y[i]+k_W*Wy[i] + RotY)
    C_Arrow.set_data(x[i]+k_C*Cx[i] + RotX, y[i]+k_C*Cy[i] + RotY)
    return [P, V_line, V_Arrow]

kino = FuncAnimation(fig,TheMagicOfThtMovement, frames=len(t), interval=10)

plt.show()
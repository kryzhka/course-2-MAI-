import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation
import scipy.integrate 

def FuncOfMoving(y, t, M, m, a, b, J0, c, k, g):
    dy = np.zeros(4)
    dy[0] = y[2]
    dy[1] = y[3]
    
    J = J0 + m * (b**2 + y[1]**2)
    a11 = J      
    a12 = m * b 
    a21 = b
    a22 = 1


    b1 = ((M * a + m * b) * np.sin(y[0]) + m * y[1] * np.cos(y[0])) * g - c * y[0] - m * 2 * y[1] * y[2] * y[3]
    b2 = g * np.sin(y[0]) - (k / m) * y[3] + y[1] * y[2]**2
    

    dy[2] = (b1 * a22 - b2 * a12) / (a11 * a22 - a12 * a21)
    dy[3] = (b2 * a11 - b1 * a21) / (a11 * a22 - a12 * a21)

    return dy

t_fin=20
Nt=2000
t = np.linspace(0, t_fin, Nt)

M = 100
m = 10
a = 1
b = 1.5
J0 = 100
c = 2e4
k = 50
g = 99.81

phi0 = np.pi / 10
s0 = 0
dphi0 = 0
ds0 = 0
y_0 = [phi0, s0, dphi0, ds0]

Y=scipy.integrate.odeint(FuncOfMoving, y_0, t, (M, m, a, b, J0, c, k, g))

phi = Y[:, 0]
s = Y[:, 1]
dphi = Y[:, 2]
ds = Y[:, 3]



fig0 = plt.figure(figsize=[13,9])
ax1 = fig0.add_subplot(2,2,1)
ax1.plot(t,s,color=[1,0,0])  
ax1.set_title('S(t)')        

ax2 = fig0.add_subplot(2,2,2)
ax2.plot(t,phi,color=[0,1,0])
ax2.set_title('Phi(t)')

ax3 = fig0.add_subplot(2,2,3)
ax3.plot(t,ds,color=[0,0,1])
ax3.set_title("S'(t)")

ax4 = fig0.add_subplot(2,2,4)
ax4.plot(t,dphi,color=[0,0,0])
ax4.set_title("Phi'(t)")


WeightA=4#ширина нижнего блока
HeightA=2#высота нижнего блока
xTA = np.array([-WeightA/2, -WeightA/2, WeightA/2, WeightA/2,0.2*WeightA, 0, -0.2*WeightA,-WeightA/2])
yTA= np.array([-HeightA/2, HeightA/2, HeightA/2, -HeightA/2, -HeightA/2, -HeightA/2-0.825,-HeightA/2,-HeightA/2])
yTA+=HeightA

WeightB=0.4
HeightB=0.3
xTB = np.array([-WeightB/2, -WeightB/2, WeightB/2, WeightB/2,-WeightB/2])
yTB= np.array([-HeightB/2, HeightB/2, HeightB/2, -HeightB/2,-HeightB/2])
yTB+=1.5*HeightA+HeightB/2


fig = plt.figure(figsize=[25,25])
ax = fig.add_subplot(1,1,1)
ax.axis('equal')
ax.set(xlim=[-5,6],ylim=[0,10])
ax.plot([-7,-7,10],[10,0.125,0.125],color=[0,0.5,0],linewidth=2)#ск


N = 4
r1=0.2
r2=1
Beta0 = np.linspace(0,1,50*N+1)
Betas = Beta0*(N*2*np.pi-phi[0])
xS = -(r1+(r2-r1)*Betas/(N*2*np.pi-phi[0]))*np.sin(Betas)
yS = (r1+(r2-r1)*Betas/(N*2*np.pi-phi[0]))*np.cos(Betas)
SpiralnayaPruzzhina = ax.plot(xS, yS, color=[1, 0.5, 0.5])[0]


A=ax.plot(xTA,yTA,color=[1,0,0])[0]
B=ax.plot(xTB,yTB,color=[1,0,0])[0]


def draw(i):

    # A.set_data(Rot(xTA,yTA,phi[i]))
    # B.set_data(Rot((phi[i],phi[i])+xTB,yTB,phi[i]))

    A.set_data(xTA*np.cos(phi)[i] - yTA*np.sin(phi)[i],xTA*np.sin(phi)[i] + yTA*np.cos(phi)[i])
    B.set_data((xTB-s[i])*np.cos(phi)[i] - yTB*np.sin(phi)[i],(xTB-s[i])*np.sin(phi)[i] + yTB*np.cos(phi)[i])

    Betas = Beta0 * (N * 2 * np.pi*(1-1/37) + phi[i])
    xS = -(r1 + (r2 - r1) * Betas / (N * 2 * np.pi + phi[i])) * np.sin(Betas)
    yS = (r1 + (r2 - r1) * Betas / (N * 2 * np.pi + phi[i])) * np.cos(Betas)
    SpiralnayaPruzzhina.set_data(xS, yS)
    return [A,B,SpiralnayaPruzzhina]

animation=FuncAnimation(fig,draw,frames=Nt,interval=t_fin)
plt.show()
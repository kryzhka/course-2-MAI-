import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation


t = np.linspace(0, 10, 1001)
x = 0.5 * (1+0.3*np.sin(0.8 * t)+0.5*np.cos(3.43*t))
phi = 1.2 * np.cos(2.14 * t)

W = 0.8  # длина тележки
H = 0.2  # высота тележки
r = 0.08  # радиус колёс
x0 = 0.7  # положение равновесия пружинки
l = 1 # длина палки

xA = x0 + W / 2 + x
yA = 2*r + H/2
xB = xA + l*np.sin(phi)
yB = yA + l*np.cos(phi)
xT = np.array([-W/2, -W/2, W/2, W/2, 0.28*W, 0.3*W, 0.32*W, -0.32*W, -0.3*W, -0.28*W, -W/2])
yT = np.array([-H/2, H/2, H/2, -H/2, -H/2,-H/2-r,-H/2,-H/2,-H/2-r,-H/2,-H/2])
Alpha = np.linspace(0,6.29,50)
xK = r*np.sin(Alpha)
yK = r*np.cos(Alpha)

n = 13
h = 0.05
xP = np.linspace(0,1,2*n+1)
yP = np.zeros(2*n+1)
ss = 0
for i in range(2*n+1):
    yP[i] = h*np.sin(ss)
    ss += np.pi/2

N = 4
r1=0.03
r2=0.1
Beta0 = np.linspace(0,1,50*N+1)
Betas = Beta0*(N*2*np.pi-phi[0])
xS = -(r1+(r2-r1)*Betas/(N*2*np.pi-phi[0]))*np.sin(Betas)
yS = (r1+(r2-r1)*Betas/(N*2*np.pi-phi[0]))*np.cos(Betas)


fig = plt.figure(figsize=[13,9])
ax = fig.add_subplot(1,1,1)
ax.axis('equal')
ax.set(xlim=[-0.25,3],ylim=[-0.25,2])

ax.plot([0,0,2.75],[1.75,0,0],color=[0,0.5,0],linewidth=4)

SpiralnayaPruzzhina = ax.plot(xS+xA[0], yS+yA, color=[1, 0.5, 0.5])[0]
Pruzzhina = ax.plot(xP*(x0+x[0]), yP+yA, color=[0.5, 0.5, 1])[0]


Telega = ax.plot(xA[0]+xT,yA+yT,color=[0,0,0])[0]
AB = ax.plot([xA[0], xB[0]], [yA, yB[0]], color=[1,0,0])[0]
A = ax.plot(xA[0],yA,'o',color=[1,0,0])[0]
B = ax.plot(xB[0],yB[0],'o',color=[0,0.75,0],markersize=20,markerfacecolor=[0,1,0],linewidth=2)[0]
K1 = ax.plot(xK+xA[0]-W*0.3,yK+r,color=[0,0,0])[0]
K2 = ax.plot(xK+xA[0]+W*0.3,yK+r,color=[0,0,0])[0]


def kadr(i):
    A.set_data(xA[i],yA)
    B.set_data(xB[i], yB[i])
    AB.set_data([xA[i], xB[i]], [yA, yB[i]])
    Telega.set_data(xA[i]+xT, yA+yT)
    K1.set_data(xK+xA[i]-W*0.3,yK+r)
    K2.set_data(xK + xA[i] + W * 0.3, yK + r)
    Pruzzhina.set_data(xP*(x0+x[i]), yP+yA)

    Betas = Beta0 * (N * 2 * np.pi - phi[i])
    xS = -(r1 + (r2 - r1) * Betas / (N * 2 * np.pi - phi[i])) * np.sin(Betas)
    yS = (r1 + (r2 - r1) * Betas / (N * 2 * np.pi - phi[i])) * np.cos(Betas)
    SpiralnayaPruzzhina.set_data(xS+xA[i], yS+yA)
    return [A, B, AB, Telega, K1, K2, Pruzzhina, SpiralnayaPruzzhina]

kino = FuncAnimation(fig,kadr,interval = t[1]-t[0],frames=len(t))

plt.show()
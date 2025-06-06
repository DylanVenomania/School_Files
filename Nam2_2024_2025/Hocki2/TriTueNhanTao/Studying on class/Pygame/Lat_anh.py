import pygame

pygame.init()

screen = pygame.display.set_mode((800,600))
pygame.display.set_caption("Lật ảnh")


image = pygame.image.load(r"D:\Nam2_2024_2025\Hocki2\TriTueNhanTao\Pygame\Violet.jpg")  

latngang = pygame.transform.flip(image, True, False)

latdoc = pygame.transform.flip(image, False, True)

lat2chieu = pygame.transform.flip(image, True, True)

screen.blit(image, (50, 100)) 
screen.blit(latngang, (300, 100))  
screen.blit(latdoc, (550, 100))  
screen.blit(lat2chieu, (300, 350))  

pygame.display.flip()  

running = True
while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False


pygame.quit()
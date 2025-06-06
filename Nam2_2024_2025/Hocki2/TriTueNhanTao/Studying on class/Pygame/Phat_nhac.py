import pygame

pygame.init()
pygame.mixer.init()

pygame.mixer.music.load(r"D:\Nam2_2024_2025\Hocki2\TriTueNhanTao\Pygame\Sakura.mp3")  
pygame.mixer.music.play(-1)  

screen = pygame.display.set_mode((600, 400))
pygame.display.set_caption("Phát nhạc nền")

running = True
while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

pygame.quit()
CREATE DATABASE IF NOT EXISTS venda_quadros;
USE venda_quadros;

CREATE TABLE IF NOT EXISTS artistas(
    id_artista INT PRIMARY KEY,
    nome_artista VARCHAR(100) NOT NULL,
    nacionalidade VARCHAR(50),
    estilo_artista VARCHAR(50)
);

CREATE TABLE IF NOT EXISTS clientes(
    id_cliente INT PRIMARY KEY,
    nome_cliente VARCHAR(100) NOT NULL,
    email_cliente VARCHAR(100) NOT NULL,
    telefone_cliente VARCHAR(15)
);

CREATE TABLE IF NOT EXISTS quadros(
    id_quadro INT PRIMARY KEY,
    id_artista INT,
    titulo_quadro VARCHAR(100) NOT NULL,
    ano_criacao INT,
    preco DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (id_artista) REFERENCES artistas(id_artista)
);

CREATE TABLE IF NOT EXISTS pedidos (
    id_pedido INT PRIMARY KEY AUTO_INCREMENT,
    id_cliente INT,
    data_pedido DATE NOT NULL,
    status_pedido VARCHAR(20) DEFAULT 'Em Processamento',
    FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente)
);

CREATE TABLE IF NOT EXISTS detalhes_pedido (
    id_detalhe INT PRIMARY KEY AUTO_INCREMENT,
    id_pedido INT,
    id_quadro INT,
    quantidade INT NOT NULL,
    preco_unitario DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (id_pedido) REFERENCES pedidos(id_pedido),
    FOREIGN KEY (id_quadro) REFERENCES quadros(id_quadro)
);

INSERT INTO artistas (id_artista, nome_artista, nacionalidade, estilo_artista)
VALUES
    (1, 'Vincent van Gogh', 'Holandesa', 'Pós-Impressionismo'),
    (2, 'Leonardo da Vinci', 'Italiana', 'Renascimento'),
    (3, 'Frida Kahlo', 'Mexicana', 'Surrealismo');

INSERT INTO clientes (id_cliente, nome_cliente, email_cliente, telefone_cliente)
VALUES
    (1, 'João Silva', 'joao@email.com', '123-456-7890'),
    (2, 'Maria Oliveira', 'maria@email.com', '987-654-3210'),
    (3, 'Carlos Pereira', 'carlos@email.com', '555-123-4567');

INSERT INTO quadros (id_quadro, id_artista, titulo_quadro, ano_criacao, preco)
VALUES
    (1, 1, 'Noite Estrelada', 1889, 1500.00),
    (2, 2, 'Mona Lisa', 1503, 5000.00),
    (3, 3, 'As Duas Fridas', 1939, 2000.00);

INSERT INTO pedidos (id_cliente, data_pedido)
VALUES
    (1, '2023-01-01'),
    (2, '2023-02-15'),
    (3, '2023-03-20');

INSERT INTO detalhes_pedido (id_pedido, id_quadro, quantidade, preco_unitario)
VALUES
    (1, 1, 2, 1500.00),
    (2, 2, 1, 5000.00),
    (3, 3, 3, 2000.00);
    


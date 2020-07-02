require 'socket'

p "Server is running"

u = UDPSocket.new
u.bind("127.0.0.1", 3000)

@port = 3001
BasicSocket.do_not_reverse_lookup = true
@socket = UDPSocket.new
@socket.setsockopt(Socket::SOL_SOCKET, Socket::SO_BROADCAST, 1)
@socket.bind("127.0.0.1", 3001)
@clientPorts = []

def listen(u)
  while msg = u.recv(90000).bytes.to_a
    broadcast(msg, @clientPorts)
  end
end

def broadcast(msg, clients)
  clients.each do |client|
    @socket.send(msg.pack('C*'), 0, '127.0.0.1', client[1])
  end
end

Thread.new { listen(u) }

while true
  client = @socket.recvfrom(1024)

  Thread.new(client) do |clientAddress|
    unless @clientPorts.include? clientAddress[1]
      @clientPorts << clientAddress[1]
    end
  end
end
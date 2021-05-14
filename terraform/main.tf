resource "digitalocean_ssh_key" "default_ssh" {
  name       = var.ssh_name
  public_key = file(var.pub_key)
}

resource "digitalocean_vpc" "vpc" {
  name     = var.droplet_name
  region   = var.region
  ip_range = "10.10.12.0/24"
}

resource "digitalocean_droplet" "default" {
  image = var.droplet_image
  name = var.droplet_name
  region = var.region
  vpc_uuid = digitalocean_vpc.vpc.id
  size = var.droplet_size
  ssh_keys = [ digitalocean_ssh_key.default_ssh.fingerprint ]
  user_data = file("user-data.sh")
  tags = [ var.droplet_name ]
  connection {
    user = "root"
    type = "ssh"
    port=22
    private_key = file(var.pvt_key)
    timeout = "3m"
  }
}

resource "digitalocean_firewall" "do_firewall" {
  name  = var.droplet_name
  // tags  = [ var.droplet_name ]
  count = "1"

  inbound_rule {
      protocol                = "tcp"
      port_range              = "22"
      source_addresses        = ["0.0.0.0/0", "::/0"]
    }
  inbound_rule {
      protocol                = "tcp"
      port_range              = "2222"
      source_addresses        = ["0.0.0.0/0", "::/0"]
    }

  inbound_rule {
      protocol                = "tcp"
      port_range              = "535"
      source_addresses        = ["0.0.0.0/0", "::/0"]
    }
  inbound_rule {
      protocol                = "tcp"
      port_range              = "80"
      source_addresses        = ["0.0.0.0/0", "::/0"]
    }
  inbound_rule {
      protocol                = "tcp"
      port_range              = "443"
      source_addresses        = ["0.0.0.0/0", "::/0"]
    }

  inbound_rule {
      protocol                = "tcp"
      port_range              = "1433"
      source_addresses        = ["0.0.0.0/0", "::/0"]
    }

  outbound_rule {
      protocol                = "tcp"
      port_range              = "all"
      destination_addresses   = ["0.0.0.0/0", "::/0"]
    }
  outbound_rule {
      protocol                = "udp"
      port_range              = "all"
      destination_addresses   = ["0.0.0.0/0", "::/0"]
    }
  outbound_rule {
      protocol                = "icmp"
      destination_addresses   = ["0.0.0.0/0", "::/0"]
    }
}

resource "digitalocean_project" "do_porject" {
  name        = var.droplet_name
  description = "A project to represent development resources."
  purpose     = "Web Application"
  environment = "Development"
  resources   = [digitalocean_droplet.default.urn]
}

# Add an A record to the domain
# resource "digitalocean_record" "auth_subdomain" {
#   domain = var.domain
#   type   = "A"
#   name   = var.auth_subdomain
#   value  = digitalocean_droplet.default.ipv4_address
#   ttl    = 3600
# }

# Add an A record to the domain
# resource "digitalocean_record" "api_subdomain" {
# domain = var.domain
# type   = "A"
# name   = var.api_subdomain
# value  = digitalocean_droplet.default.ipv4_address
# ttl    = 3600
#}

# Add an A record to the domain
resource "digitalocean_record" "landing_subdomain" {
  domain = var.domain
  type   = "A"
  name   = var.landing_subdomain
  value  = digitalocean_droplet.default.ipv4_address
  ttl    = 3600
}
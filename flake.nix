{
  description = "Dev shell for KH_MUD .NET project";

  inputs = {
    # Pin to a nixpkgs revision that already packages the .NET 10 SDK attribute.
    # Update this hash when you want newer packages.
    nixpkgs.url = "github:nixos/nixpkgs/ee09932cedcef15aaf476f9343d1dea2cb77e261";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem (system:
      let
        pkgs = import nixpkgs {
          inherit system;
          # If you need to allow unfree packages (sometimes required for some SDKs), set this to true.
          config.allowUnfree = true;
        };
      in {
        devShells.default = pkgs.mkShell {
          # Explicitly use the .NET 10 SDK from nixpkgs.
          buildInputs = [
            pkgs.dotnet-sdk_10
            pkgs.dotnet-format
          ];

          # Extra environment setup if needed
          shellHook = ''
            echo "KH_MUD dev shell with .NET SDK is ready."
            echo "You can now run: dotnet restore && dotnet build && dotnet run"
            echo "Run 'dotnet format' for C# formatting."
          '';
        };
        formatter = pkgs.nixpkgs-fmt;
      });
}

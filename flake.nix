{
  description = "Dev shell for KH_MUD .NET project";

  inputs = {
    # You can change this to a specific revision or a different channel if you want.
    nixpkgs.url = "github:nixos/nixpkgs/nixos-unstable";
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
          # .NET SDK – this will normally be the latest SDK (often newest LTS or STS).
          # If you specifically need .NET 10 once it lands in nixpkgs, you can
          # switch to the appropriate package here (e.g. pkgs.dotnet-sdk-10 or similar).
          buildInputs = [
            pkgs.dotnet-sdk
          ];

          # Extra environment setup if needed
          shellHook = ''
            echo "KH_MUD dev shell with .NET SDK is ready."
            echo "You can now run: dotnet restore && dotnet build && dotnet run"
          '';
        };
      });
}




import base64
import os
from cryptography.fernet import Fernet, InvalidToken
from cryptography.hazmat.backends import default_backend
from cryptography.hazmat.primitives import hashes
from cryptography.hazmat.primitives.kdf.pbkdf2 import PBKDF2HMAC

SALT = b"svlet_salt123456"  # 16 bytes

# https://cryptography.io/en/latest/fernet/

class FernetCipher:
    def __init__(self, password):
        passwordBytes = bytes(password, encoding = "utf8")
        kdf = PBKDF2HMAC(
            algorithm=hashes.SHA256(),
            length=32,
            salt=SALT,
            iterations=100000,
            backend=default_backend()
        )
        self._derivation = base64.urlsafe_b64encode(kdf.derive(passwordBytes))
        self._fernet = Fernet(self._derivation)

    def encode(self, message):
        encoded = self._fernet.encrypt(bytes(message, encoding = "utf8"))
        # print("encrypted: ", encoded)
        return str(encoded, encoding = "utf8")

    def decode(self, encryted):
        try:
            plain = self._fernet.decrypt(bytes(encryted, encoding = "utf8"))
            # print("plain: ", plain)
            return str(plain, encoding = "utf8")
        except InvalidToken:
            raise Exception("FernetCipher: invalid token")

def test_basic():
    fc = FernetCipher("abc")
    original = "hello"
    plain = fc.decode(fc.encode(original))
    assert original==plain

if __name__ == "__main__":
    test_basic()